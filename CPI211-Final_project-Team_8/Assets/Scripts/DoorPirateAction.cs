using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("SOLVED");
        }
    }
}
