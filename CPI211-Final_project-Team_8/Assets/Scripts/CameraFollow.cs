using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float snapSpeed = 64.0f;
    public Vector3 offset = new Vector3(0.0f, 5.0f, -10.0f);
    public float maxInfluenceDistance = 8.0f;
    public bool influenceable = true;

    private bool focusing;
    private bool pause = true;
    private GameObject focus;
    private Vector3 focusOffset;
    private Vector3 defaultOffset;

    private float snapTimer = 0.0f;

    void Start()
    {
        target = FindObjectOfType<PlayerHandler>().gameObject;
        defaultOffset = offset;
    }

    void Update()
    {
        if (!focusing)
        {
            if (!FindObjectOfType<DialogueRender>().GetShown())
            {
                Time.timeScale = 1.0f;
            }
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * snapSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), snapSpeed / 2 * Time.deltaTime);
        }
        else
        {
            if (pause)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
            transform.position = Vector3.Lerp(transform.position, focus.transform.position + focusOffset, snapSpeed * Time.unscaledDeltaTime * snapSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(focus.transform.position - transform.position), snapSpeed * Time.unscaledDeltaTime * snapSpeed);
        }
        if(offset != defaultOffset)
        {
            if(snapTimer > 0.0f)
            {
                snapTimer -= Time.unscaledDeltaTime;
            }
            else
            {
                offset = Vector3.Lerp(offset, defaultOffset, Time.unscaledDeltaTime);
            }
        }
    }

    public void Influence(Vector3 influence)
    {
        if(Vector3.Distance(Vector3.Lerp(offset, offset + influence, Time.unscaledDeltaTime), defaultOffset) < maxInfluenceDistance && influenceable)
        {
            offset = Vector3.Lerp(offset, defaultOffset + influence, Time.unscaledDeltaTime);
            snapTimer = 0.1f;
        }
    }

    public void ChangeAngle(Vector3 newAngle)
    {
        defaultOffset = newAngle;
    }

    public Vector3 GetAngle()
    {
        return defaultOffset;
    }

    public void Focus(GameObject obj, Vector3 offsetPos) 
    {
        focusing = true;
        focus = obj;
        focusOffset = offsetPos;
        pause = true;
    }

    public void Focus(GameObject obj, Vector3 offsetPos, bool toPause)
    {
        focusing = true;
        focus = obj;
        focusOffset = offsetPos;
        pause = toPause;
    }

    public void Unfocus()
    {
        focusing = false;
    }
}