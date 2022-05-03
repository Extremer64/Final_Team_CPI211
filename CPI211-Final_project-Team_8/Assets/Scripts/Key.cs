using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ItemHandler
{
    public int level;
    public bool active = false;

    private Switchboard switchboard;

    void Start()
    {
        switchboard = FindObjectOfType<Switchboard>();
    }

    void Update()
    {
        if (active)
        {
            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().enabled = true;
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
