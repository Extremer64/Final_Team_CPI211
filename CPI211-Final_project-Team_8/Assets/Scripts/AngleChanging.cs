using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleChanging : MonoBehaviour
{
    public bool inField;

    public Vector3 newAngle;

    private Vector3 defaultAngle;
    private CameraFollow cameraFollow;

    void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
        defaultAngle = cameraFollow.offset;
    }
    void Update()
    {
        if (inField && cameraFollow.GetAngle() != newAngle)
        {
            cameraFollow.ChangeAngle(newAngle);
            cameraFollow.influenceable = false;
        }
        else if(!inField && cameraFollow.GetAngle() == newAngle)
        {
            cameraFollow.ChangeAngle(defaultAngle);
            cameraFollow.influenceable = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerHandler>(out PlayerHandler playerHandler))
        {
            inField = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerHandler>(out PlayerHandler playerHandler))
        {
            inField = false;
        }
    }
}
