using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private inputHandle _in;
    private AudioSource source;
    private bool footsteps = false;

    [SerializeField]
    private float moveS;

    private void Awake()
    {
        _in = GetComponent<inputHandle>();
        source = GetComponent<AudioSource>();
        source.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        var targetVect = new Vector3(_in.InputVector.x, _in.InputVector.y * 3, _in.InputVector.z);
        MovePlayer(targetVect);
        if(targetVect != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetVect), moveS * Time.deltaTime);
            if(!footsteps)
            {
                source.Play();
                footsteps = true;
            }
        }

        if(targetVect == Vector3.zero && footsteps)
        {
            source.Pause();
            footsteps = false;
        }
    }

    private void MovePlayer(Vector3 targetV) {
        //var spd = moveS * Time.deltaTime;
        //transform.Translate(targetV * spd);
        GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(transform.position, transform.position + targetV, moveS * Time.deltaTime));
    }
}
