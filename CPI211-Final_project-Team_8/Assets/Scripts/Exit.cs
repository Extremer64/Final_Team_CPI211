using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : Interactable
{
    public int level = 0;
    public int nextLevel;

    private Switchboard switchboard;

    void Start()
    {
        switchboard = FindObjectOfType<Switchboard>();
    }

    public override void Interact()
    {
        if (switchboard.CheckKey(level))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
