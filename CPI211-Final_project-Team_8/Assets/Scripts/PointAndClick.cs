using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
    public Vector3 clickOffset;

    public float delayTime = 1.0f;

    private PlayerHandler player;
    private RaycastHit hit;
    private TravelPoint travPoint;
    private CameraFollow cameraFollow;

    private float delay;
    
    void Start()
    {
        travPoint = FindObjectOfType<TravelPoint>();
        player = FindObjectOfType<PlayerHandler>();
        cameraFollow = GetComponent<CameraFollow>();
    }

    void FixedUpdate()
    {
        if(delay < 0.0f)
        {
            if (Input.GetMouseButton(0))
            {
                delay = delayTime;
                if (Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit))
                {
                    switch (GetType(hit.transform.gameObject))
                    {
                        case "Item":
                            travPoint.transform.position = FindGround(hit).point + clickOffset;
                            player.AddItem(hit.transform.gameObject.GetComponent<ItemHandler>());
                            break;
                        case "NPC":
                            travPoint.transform.position = FindGround(hit).point + clickOffset;
                            player.AddNPC(hit.transform.gameObject.GetComponent<NPC>());
                            break;
                        case "Interactable":
                            travPoint.transform.position = FindGround(hit).point + clickOffset;
                            player.AddInteract(hit.transform.gameObject.GetComponent<Interactable>());
                            break;
                        default:
                            travPoint.transform.position = FindGround(hit).point + clickOffset;
                            travPoint.SetActive();
                            break;
                    }
                }
            }
        }
        else
        {
            delay -= Time.deltaTime;
        }
        if (Input.GetMouseButton(1))
        {
            cameraFollow.Influence(new Vector3(Input.mousePosition.x - Screen.width/2, 0, Input.mousePosition.y - Screen.height/2).normalized * 4.0f);
        }
    }
    
    private string GetType(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<NPC>(out NPC npc))
        {
            return "NPC";
        }
        if (gameObject.TryGetComponent<ItemHandler>(out ItemHandler itemHandler))
        {
            return "Item";
        }
        if(gameObject.TryGetComponent<Interactable>(out Interactable interactable))
        {
            return "Interactable";
        }
        return "default";
    }
    private RaycastHit FindGround(RaycastHit raycastHit)
    {
        if (NavMesh.SamplePosition(hit.point + Vector3.forward, out NavMeshHit meshHit, 1000.0f, NavMesh.AllAreas))
        {
            raycastHit.point = meshHit.position;
        }
        return raycastHit;
    }
}