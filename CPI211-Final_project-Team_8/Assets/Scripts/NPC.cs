using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int dialogueIndex = 0;

    public AudioClip audioClip;

    private bool isTalking = false;
    private int lineIndex = 0;
    private int lastDialogue = -1;

    private Dialogue dialogue;
    private DialogueRender render;

    void Start()
    {
        dialogue = GetComponent<Dialogue>();
        render = FindObjectOfType<DialogueRender>();
        if(!TryGetComponent<Highlightable>(out Highlightable highlightable))
        {
            gameObject.AddComponent<Highlightable>();
        }
    }

    void FixedUpdate()
    {
        if (isTalking)
        {
            if (lineIndex == dialogue.lines[dialogueIndex].line.Length)
            {
                isTalking = false;
                lastDialogue = dialogueIndex;
            }
            else if (dialogue.lines[dialogueIndex].line[lineIndex].Contains("ACTION:"))
            {
                RunAction(dialogue.lines[dialogueIndex].line[lineIndex].Substring(7));
                lineIndex++;
            }
            else
            {
                if(audioClip != null)
                {
                    render.ShowText(dialogue.lines[dialogueIndex].line[lineIndex], audioClip);
                }
                else
                {
                    render.ShowText(dialogue.lines[dialogueIndex].line[lineIndex]);
                }
                lineIndex++;
            }
        }
    }

    public bool GetTalking()
    {
        return isTalking;
    }
    public void EnterDialogue()
    {
        lineIndex = 0;
        if (lastDialogue < dialogue.lines.Length - 1)
        {
            dialogueIndex = lastDialogue + 1;
        }
        isTalking = true;
    }
    public void EnterDialogue(int index)
    {
        lineIndex = 0;
        dialogueIndex = index;
        isTalking = true;
    }
    public void RunAction(string actionIndex)
    {
        Action[] actions = GetComponents<Action>();
        foreach (Action action in actions)
        {
            if (action.GetTag().Equals(actionIndex))
            {
                action.DoAction();
            }
        }
    }
}
