using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
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
            Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Ground"))
                {
                    travPoint.transform.position = hit.point;
                    travPoint.SetActive();
                }
            }
        }
    }
}
