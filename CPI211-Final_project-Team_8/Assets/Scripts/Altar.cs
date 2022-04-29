using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : Interactable
{
    public bool solved = false;
    public float focusTime = 1.0f;

    public Key key;

    private float focusTimer = 0.0f;

    private CameraFollow cameraFollow;
    private Switchboard switchboard;

    void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
        switchboard = FindObjectOfType<Switchboard>();
    }

    void Update()
    {
        if (focusTimer > 0.0f)
        {
            focusTimer -= Time.unscaledDeltaTime;
        }
        else if (focusTimer < 0.0f)
        {
            if (solved)
            {
                key.active = true;
            }
            focusTimer = 0.0f;
            cameraFollow.Unfocus();
        }
    }

    public override void Interact()
    {
        if (switchboard.CheckRitualPieces())
        {
            solved = true;
        }
        else
        {
            solved = false;
        }
        GetComponent<Collider>().enabled = false;
        focusTimer = focusTime;
        cameraFollow.Focus(gameObject, Vector3.up * 12.0f);
    }
}
