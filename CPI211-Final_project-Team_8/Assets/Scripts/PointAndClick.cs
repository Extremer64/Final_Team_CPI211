using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
    public Vector3 clickOffset;

    private RaycastHit hit;
    private TravelPoint travPoint;
    
    void Start()
    {
        travPoint = FindObjectOfType<TravelPoint>();
    }

    void Update()
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
                        //item code
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
