using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueRender : MonoBehaviour
{
    [Range(1.0f, 100.0f)]
    public float textSpeed = 50.0f;
    
    private bool dialogueShown;
    private string dialogueText;
    private char[] textArray;
    private int charPos;
    private float textCounter = 0.0f;

    private string defaultText;

    private Text textEditor;
    private GameObject canvas;
    private AudioSource audioSource;

    void Start()
    {
        textEditor = GetComponentInChildren<Text>();
        defaultText = textEditor.text;
        canvas = GetComponentsInChildren<Transform>()[1].gameObject;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true;
    }

    void Update()
    {
        if (dialogueShown)
        {
            canvas.SetActive(true);
            Time.timeScale = 0.0f;
            if(charPos == textArray.Length)
            {
                audioSource.Stop();
                if (Input.anyKey)
                {
                    dialogueShown = false;
                }
            }
            else if (textCounter > (1.0f/textSpeed))
            {
                textCounter = 0.0f;
                dialogueText += textArray[charPos];
                charPos++;
                textEditor.text = dialogueText;
            }
            else
            {
                textCounter += Time.unscaledDeltaTime;
            }
        }
        else
        {
            Time.timeScale = 1.0f;
            canvas.SetActive(false);
            if (Input.GetKey(KeyCode.Backspace))
            {
                ShowText(defaultText);
            }
        }
    }

    public bool GetShown()
    {
        return dialogueShown;
    }
    public void ShowText(string text)
    {
        textEditor.text = "";
        dialogueText = "";
        textArray = text.ToCharArray();
        charPos = 0;
        dialogueShown = true;
        audioSource.clip = null;
    }
    public void ShowText(string text, AudioClip audio)
    {
        textEditor.text = "";
        dialogueText = "";
        textArray = text.ToCharArray();
        charPos = 0;
        dialogueShown = true;
        audioSource.clip = audio;
        audioSource.Play();
    }
    public bool DialogueFinished()
    {
        if (textEditor.text == dialogueText) {
            return true;
        }
        return false;
    }
}
