using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int dialogueIndex = 0;

    private bool isTalking = false;
    private int lineIndex = 0;
    private int lastDialogue = -1;

    private Dialogue dialogue;
    private DialogueRender render;

    void Start()
    {
        dialogue = GetComponent<Dialogue>();
        render = FindObjectOfType<DialogueRender>();
    }

    void FixedUpdate()
    {
        if (isTalking)
        {
            if(lineIndex == dialogue.lines[dialogueIndex].line.Length)
            {
                isTalking = false;
                lastDialogue = dialogueIndex;
            }
            else
            {
                render.ShowText(dialogue.lines[dialogueIndex].line[lineIndex]);
                lineIndex++;
            }
        }
    }

    public void EnterDialogue()
    {
        lineIndex = 0;
        if(lastDialogue < dialogue.lines.Length - 1)
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
}
