using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private inputHandle _in;
    private AudioSource source;
    private bool footsteps = false;
    private int collisionCount = 0;
    public float jumpDelay = 0.25f;
    private float jumpTracker = 0.0f;

    [SerializeField]
    private float moveS;

    private void Awake()
    {
        //_in = GetComponent<inputHandle>();
        source = GetComponent<AudioSource>();
        source.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVect = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (collisionCount != 0 && Input.GetAxis("Jump") > 0.0f && jumpTracker == 0.0f)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 32.0f * moveS);
            jumpTracker = jumpDelay;
        }
        else if (jumpTracker > 0.0f)
        {
            jumpTracker -= Time.deltaTime;
        }
        else if (jumpTracker < 0.0f)
        {
            jumpTracker = 0.0f;
        }
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


    //Detect when the object touches the ground and when it leaves, modifying drag accordingly
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            collisionCount++;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            collisionCount--;
        }
    }
}
