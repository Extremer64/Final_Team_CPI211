using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHandler : MonoBehaviour
{
    private bool isMoving = false;

    private NavMeshAgent navMesh;
    private TravelPoint travPoint;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isMoving)
        {
            navMesh.SetDestination(travPoint.transform.position);
            if(Vector3.Distance(transform.position, travPoint.transform.position) < 1.0f)
            {
                isMoving = false;
                travPoint.SetInactive();
            }
        }
    }

    public void AddPoint(TravelPoint newPoint)
    {
        travPoint = newPoint;
        isMoving = true;
    }
}