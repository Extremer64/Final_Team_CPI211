using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float snapSpeed = 64.0f;
    public Vector3 offset = new Vector3(0.0f, 5.0f, -10.0f);

    private bool focusing;
    private GameObject focus;
    private Vector3 focusOffset;
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
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, snapSpeed * Time.unscaledDeltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), snapSpeed * Time.unscaledDeltaTime);
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