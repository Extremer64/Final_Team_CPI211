using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
    public Vector3 clickOffset;

    private PlayerHandler player;
    private RaycastHit hit;
    private TravelPoint travPoint;
    
    void Start()
    {
        travPoint = FindObjectOfType<TravelPoint>();
        player = FindObjectOfType<PlayerHandler>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.tag)
                {
                    case "Ground":
                        travPoint.transform.position = hit.point + clickOffset;
                        travPoint.SetActive();
                        break;
                    case "Item":
                        travPoint.transform.position = hit.point + clickOffset;
                        player.AddItem(hit.transform.gameObject.GetComponent<ItemHandler>());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
