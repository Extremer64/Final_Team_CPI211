using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputHandle : MonoBehaviour
{
    public Vector3 InputVector { get; private set; }
    private int jumpCD = 1000;
    private int curJump = 0;
    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        float j = 0;
        if (curJump >= jumpCD)
        {
            j = Input.GetAxis("Jump");
        } else
        {
            curJump++;
            j = 0;
        }
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector3(h, j, v);
    }
}
