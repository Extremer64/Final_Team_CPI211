using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float snapSpeed = 64.0f;
    public Vector3 offset = new Vector3(0.0f, 5.0f, -10.0f);
    public float maxInfluenceDistance = 8.0f;

    private bool focusing;
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
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, snapSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), snapSpeed / 2 * Time.deltaTime);
        }
        else
        {
            Time.timeScale = 0.0f;
            transform.position = Vector3.Lerp(transform.position, focus.transform.position + focusOffset, snapSpeed * Time.unscaledDeltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(focus.transform.position - transform.position), snapSpeed * Time.unscaledDeltaTime);
        }
        if(offset != defaultOffset && !Input.GetMouseButton(1))
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
        if(Vector3.Distance(Vector3.Lerp(offset, offset + influence, Time.unscaledDeltaTime), defaultOffset) < maxInfluenceDistance)
        {
            offset = Vector3.Lerp(offset, defaultOffset + influence, Time.unscaledDeltaTime);
            snapTimer = 0.1f;
        }
    }

    public void Focus(GameObject obj, Vector3 offsetPos) 
    {
        focusing = true;
        focus = obj;
        focusOffset = offsetPos;
    }

    public void Unfocus()
    {
        focusing = false;
    }
}