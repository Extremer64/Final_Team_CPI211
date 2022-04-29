using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : Interactable
{
    public bool dug = false;
    public bool isSkeleton = false;

    private float digTime = 1.0f;
    private float digTimer = 0.0f;

    private CameraFollow cameraFollow;

    void Start()
    {
        interactTag = "Grave";
        cameraFollow = FindObjectOfType<CameraFollow>();
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
        }
    }

    public override void Interact()
    {
        if (!dug)
        {
            dug = true;
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
        Debug.Log("Don't Skeleton");
        /*---------------------------------------------------------------------------
         *                LINK TO A SCRIPT TO *DON'T* SPAWN SKELETON
         *               or just leave blank and it'll just sit there
         *                                   - SCOUT
         *-------------------------------------------------------------------------*/
    }
}
