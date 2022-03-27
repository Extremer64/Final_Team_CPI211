using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private inputHandle _in;

    [SerializeField]
    private float moveS;

    private void Awake()
    {
        _in = GetComponent<inputHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        var targetVect = new Vector3(_in.InputVector.x, _in.InputVector.y * 3, _in.InputVector.z);
        MovePlayer(targetVect);
        if(targetVect != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetVect), moveS * Time.deltaTime);
        }
    }

    private void MovePlayer(Vector3 targetV) {
        var spd = moveS/* * Time.deltaTime*/;
        //transform.Translate(targetV * spd);
        GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(transform.position, transform.position + targetV * spd, Time.deltaTime));
    }
}
