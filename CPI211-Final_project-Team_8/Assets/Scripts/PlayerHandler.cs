using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHandler : MonoBehaviour
{
    public float deactivationRange = 2.5f;

    private bool isMoving = false;
    private bool isGathering = false;
    private bool isApproaching = false;
    private bool isInteracting = false;

    private Switchboard switchboard;
    private NavMeshAgent navMesh;
    private NavMeshHit hit;
    private TravelPoint travPoint;
    private ItemHandler itemTarget;
    private NPC npcTarget;
    private Interactable interactTarget;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        switchboard = FindObjectOfType<Switchboard>();
        travPoint = FindObjectOfType<TravelPoint>();
    }

    void Update()
    {
        if (isMoving)
        {
            if (navMesh.velocity.magnitude.Equals(0.0f) || Input.GetMouseButton(0))
            {
                navMesh.SetDestination(travPoint.transform.position);
            }
            if (Vector3.Distance(transform.position, travPoint.transform.position) < deactivationRange || navMesh.pathStatus != NavMeshPathStatus.PathComplete)
            {
                isMoving = false;
                travPoint.SetInactive();
                navMesh.SetDestination(transform.position);
            }
        }
        else if (isGathering)
        {
            if (navMesh.velocity.magnitude.Equals(0.0f) || Input.GetMouseButton(0))
            {
                navMesh.SetDestination(itemTarget.transform.position);
            }
            if (navMesh.pathStatus != NavMeshPathStatus.PathComplete)
            {
                Debug.LogError("Path Not Found");
                navMesh.SetDestination(transform.position);
                travPoint.SetInactive();
            }
            else if (Vector3.Distance(transform.position, itemTarget.transform.position) < deactivationRange)
            {
                isGathering = false;
                if (itemTarget.TryGetComponent<PuzzlePiece>(out PuzzlePiece puzzle))
                {
                    if (!switchboard.puzzlePieces[puzzle.puzzleIndex])
                    {
                        switchboard.puzzlePieces[puzzle.puzzleIndex] = true;
                        switchboard.puzzlePiecesInv[puzzle.puzzleIndex] = puzzle;
                    }
                }
                else if (itemTarget.TryGetComponent<Key>(out Key key))
                {
                    switchboard.levelComplete[key.level] = true;
                }
                else
                {
                    Debug.LogError("Item Type Not Found");
                }
                navMesh.SetDestination(transform.position);
                itemTarget.transform.position = new Vector3(0, -10000, 0);
                travPoint.SetInactive();
            }
        }
        else if (isApproaching)
        {
            if (navMesh.velocity.magnitude.Equals(0.0f) || Input.GetMouseButton(0))
            {
                if (NavMesh.SamplePosition(npcTarget.transform.position + npcTarget.transform.forward, out hit, 1000.0f, NavMesh.AllAreas))
                {
                    navMesh.SetDestination(hit.position);
                }
                else
                {
                    Debug.LogError("Point Not Found");
                    isApproaching = false;
                }
            }
            if (navMesh.pathStatus != NavMeshPathStatus.PathComplete)
            {
                Debug.LogError("Path Not Found");
                isApproaching = false;
                navMesh.SetDestination(transform.position);
            }
            else if (Vector3.Distance(transform.position, npcTarget.transform.position) < deactivationRange * 2.5f)
            {
                isApproaching = false;
                if (!npcTarget.GetTalking())
                {
                    npcTarget.EnterDialogue();
                }
                navMesh.SetDestination(transform.position);
                travPoint.SetInactive();
            }
        }
        else if (isInteracting)
        {
            if (navMesh.velocity.magnitude.Equals(0.0f) || Input.GetMouseButton(0))
            {
                if (NavMesh.SamplePosition(interactTarget.transform.position + interactTarget.transform.forward, out hit, 1000.0f, NavMesh.AllAreas))
                {
                    navMesh.SetDestination(hit.position);
                }
                else
                {
                    Debug.LogError("Point Not Found");
                    isInteracting = false;
                }
            }
            if (navMesh.pathStatus != NavMeshPathStatus.PathComplete)
            {
                Debug.LogError("Path Not Found");
                isInteracting = false;
                navMesh.SetDestination(transform.position);
            }
            else if (Vector3.Distance(transform.position, interactTarget.transform.position) < deactivationRange * 2.0f)
            {
                isInteracting = false;
                interactTarget.Interact();
                navMesh.SetDestination(transform.position);
                travPoint.SetInactive();
            }
        }
        DrawPath();
        Debug.DrawRay(navMesh.destination, Vector3.up * 5.0f, Color.green);
    }

    public void AddPoint(TravelPoint newPoint)
    {
        travPoint = newPoint;
        ChangeTarget();
        isMoving = true;
    }

    public void AddItem(ItemHandler newItem)
    {
        itemTarget = newItem;
        ChangeTarget();
        isGathering = true;
    }

    public void AddNPC(NPC newNPC)
    {
        npcTarget = newNPC;
        ChangeTarget();
        isApproaching = true;
    }

    public void AddInteract(Interactable newInteractable)
    {
        interactTarget = newInteractable;
        ChangeTarget();
        isInteracting = true;
    }

    private void ChangeTarget()
    {
        isMoving = false;
        isGathering = false;
        isApproaching = false;
        isInteracting = false;
    }

    private void DrawPath()
    {
        var nav = GetComponent<NavMeshAgent>();
        var path = nav.path;
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }
    }
}