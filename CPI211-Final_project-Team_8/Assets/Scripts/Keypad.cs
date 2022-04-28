using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    public GameObject[] displayAndButtons = new GameObject[10];

    private bool isInterracting = false;

    private CameraFollow cameraFollow;
    private float delay = 0.0f;

    void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    void Update()
    {
        if (isInterracting)
        {
            if(delay < 2.5f)
            {
                delay += Time.unscaledDeltaTime;
            }
            else
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    cameraFollow.Unfocus();
                    isInterracting = false;
                }
            }
        }
    }

    public override void Interact()
    {
        cameraFollow.Focus(gameObject, Vector3.right * 2.0f);
        isInterracting = true;
        delay = 0.0f;
    }
}
