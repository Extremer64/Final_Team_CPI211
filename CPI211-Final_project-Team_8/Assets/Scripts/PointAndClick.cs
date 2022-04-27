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

    private float delay;
    
    void Start()
    {
        travPoint = FindObjectOfType<TravelPoint>();
        player = FindObjectOfType<PlayerHandler>();
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
                    switch (hit.transform.tag)
                    {
                        case "Ground":
                            travPoint.transform.position = hit.point + clickOffset;
                            travPoint.SetActive();
                            break;
                        case "Item":
                            travPoint.transform.position = FindGround(hit).point + clickOffset;
                            player.AddItem(hit.transform.gameObject.GetComponent<ItemHandler>());
                            break;
                        case "NPC":
                            travPoint.transform.position = FindGround(hit).point + clickOffset;
                            player.AddNPC(hit.transform.gameObject.GetComponent<NPC>());
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }
    
    private RaycastHit FindGround(RaycastHit raycastHit)
    {
        if (Physics.Raycast(raycastHit.point, Vector3.down, out raycastHit))
        {
            if (!raycastHit.transform.CompareTag("Ground"))
            {
                FindGround(raycastHit);
            }
        }
        if (NavMesh.SamplePosition(hit.point + Vector3.forward, out NavMeshHit meshHit, 1000.0f, NavMesh.AllAreas))
        {
            raycastHit.point = meshHit.position;
        }
        return raycastHit;
    }
}