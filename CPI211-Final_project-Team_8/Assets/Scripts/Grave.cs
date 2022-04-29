using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : Interactable
{
    public bool isSkeleton = false;
    public int altarPiece = 0;

    private bool dug = false;
    private float digTime = 1.0f;
    private float digTimer = 0.0f;

    private CameraFollow cameraFollow;
    private Switchboard switchboard;

    void Start()
    {
        interactTag = "Grave";
        cameraFollow = FindObjectOfType<CameraFollow>();
        switchboard = FindObjectOfType<Switchboard>();
    }

    void Update()
    {
        if (digTimer > 0.0f)
        {
            digTimer -= Time.unscaledDeltaTime;
        }
        else if (digTimer < 0.0f)
        {
            cameraFollow.Unfocus();
            if (isSkeleton)
            {
                DoSkeleton();
            }
            else
            {
                DontSkeleton();
            }
            digTimer = 0.0f;
            Destroy(GetComponent<Highlightable>());
            GetComponent<Collider>().enabled = true;
        }
    }

    public override void Interact()
    {
        if (!dug)
        {
            dug = true;
            GetComponent<Collider>().enabled = false;
            digTimer = digTime;
            cameraFollow.Focus(gameObject, Vector3.up * 12.0f);
        }
    }

    private void DoSkeleton()
    {
        Debug.Log("Do Skeleton");
        /*---------------------------------------------------------------------------
         *                     LINK TO A SCRIPT TO SPAWN SKELETON
         *                                   - SCOUT
         *-------------------------------------------------------------------------*/
    }

    private void DontSkeleton()
    {
        switchboard.ritualPieces[altarPiece] = true;
    }
}
