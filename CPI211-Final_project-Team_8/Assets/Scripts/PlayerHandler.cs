using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHandler : MonoBehaviour
{
    public float deactivationRange = 2.5f;

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
            if (navMesh.velocity.magnitude.Equals(0.0f) || Input.GetMouseButton(0))
            {
                navMesh.SetDestination(travPoint.transform.position);
            }
            if(Vector3.Distance(transform.position, travPoint.transform.position) < deactivationRange || navMesh.pathStatus != NavMeshPathStatus.PathComplete)
            {
                isMoving = false;
                travPoint.SetInactive();
                navMesh.SetDestination(transform.position);
            }
        }
    }

    public void AddPoint(TravelPoint newPoint)
    {
        travPoint = newPoint;
        isMoving = true;
    }
}