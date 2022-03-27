using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables editable in unity-editor
    public GameObject target;
    public float snapSpeed = 64.0f;
    public Vector3 offset = new Vector3(0.0f, 5.0f, -10.0f);

    void Update()
    {
        //Slowly moves to position after a key is pressed
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, snapSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), snapSpeed * Time.deltaTime);
    }
}