using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private CameraFollow cameraFollow;
    PlayerHandler pHandle;
    public GameObject player;
    private float newZ;

    void Start() { 
        interactTag = "MazeDoor";
        player = FindObjectOfType<PlayerHandler>().gameObject;
        pHandle = gameObject.GetComponent<PlayerHandler>();
    }

    void Update()
    {
        newZ = player.transform.position.z - 20;
        //Debug.Log(newZ);
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
        pHandle.Teleport(new Vector3(0,0,0));
        yield return new WaitForSeconds(.01f);
        //pHandle.disable = false;
    }
}
