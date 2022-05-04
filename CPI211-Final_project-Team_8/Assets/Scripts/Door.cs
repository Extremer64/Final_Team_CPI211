using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private CameraFollow cameraFollow;
    private AudioSource audioSource;
    public bool isCorrect;
    public AudioClip audioClip;
    PlayerHandler pHandle;
    public GameObject player;
    private float newZ;

    void Start() { 
        interactTag = "MazeDoor";
        pHandle = FindObjectOfType<PlayerHandler>();
        player = pHandle.gameObject;
        if (isCorrect)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = 1.0f;
            audioSource.loop = true;
            audioSource.clip = audioClip;
            audioSource.priority = 0;
        }
    }

    void Update()
    {
        newZ = player.transform.position.z - 20;
        //Debug.Log(newZ);
        if (isCorrect)
        {
            if(Vector3.Distance(audioSource.transform.position, player.transform.position) < 25.0f)
            {
                audioSource.volume = 0.1f + (1.0f / Vector3.Distance(audioSource.transform.position, player.transform.position));
            }
            else
            {
                audioSource.volume = 0.0f;
            }
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    public override void Interact()
    {
        moveDoor();
    }

    private void moveDoor()
    {
        //Debug.Log(pHandle.disable);
        StartCoroutine("tele");
        //Destroy(gameObject);
    }

    IEnumerator tele()
    {
        Debug.Log("Tele");
        //pHandle.disable = true;
        yield return new WaitForEndOfFrame();
        //player.transform.position = new Vector3(newZ, player.transform.position.y, player.transform.position.z);
        //player.transform.position = new Vector3(0, 0, 0);
        pHandle.Teleport(pHandle.transform.position + Vector3.forward * 20.0f);
        yield return new WaitForSeconds(.01f);
        //pHandle.disable = false;
    }
}
