using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : Interactable
{
    public int level = 0;
    public int nextLevel;

    private Switchboard switchboard;
    private AudioSource Unlock;

    void Start()
    {
        switchboard = FindObjectOfType<Switchboard>();
        Unlock = GetComponent<AudioSource>();
        Unlock.loop = false;
    }

    public override void Interact()
    {
        Unlock.Play();
        if (switchboard.CheckKey(level))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
