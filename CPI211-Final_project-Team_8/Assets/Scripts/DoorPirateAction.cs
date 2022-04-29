using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPirateAction : Action
{
    private Keypad keypad;

    void Start()
    {
        keypad = FindObjectOfType<Keypad>();
        actionTag = "DoorPirate";
    }

    public override void DoAction()
    {
        if (keypad.solved)
        {
            SceneManager.LoadScene(3);
        }
    }
}
