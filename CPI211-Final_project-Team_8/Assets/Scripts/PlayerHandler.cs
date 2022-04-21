using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHandler : MonoBehaviour
{
    public float deactivationRange = 2.5f;

    private bool isMoving = false;
    private bool isGathering = false;

    private NavMeshAgent navMesh;
    private TravelPoint travPoint;
    private ItemHandler itemTarget;

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
        if (isGathering)
        {
            if (navMesh.velocity.magnitude.Equals(0.0f) || Input.GetMouseButton(0))
            {
                navMesh.SetDestination(itemTarget.transform.position);
            }
            if (Vector3.Distance(transform.position, itemTarget.transform.position) < deactivationRange || navMesh.pathStatus != NavMeshPathStatus.PathComplete)
            {
                isGathering = false;
                navMesh.SetDestination(transform.position);
                Debug.Log("Item Picked Up: " + itemTarget.gameObject.name);
                itemTarget.transform.position = new Vector3(0, -10000, 0);
            }
        }
    }

    public void AddPoint(TravelPoint newPoint)
    {
        travPoint = newPoint;
        isMoving = true;
    }

    public void AddItem(ItemHandler newItem)
    {
        itemTarget = newItem;
        isGathering = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Item Picked Up: " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }
}