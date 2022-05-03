using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAssembly : Interactable
{
    public bool solved = false;
    public bool isInteracting = false;
    public Key key;

    private PuzzleSlot[] puzzleSlots;
    private bool[] pieces = new bool[9];
    private CameraFollow cameraFollow;
    private Switchboard switchboard;

    void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
        switchboard = FindObjectOfType<Switchboard>();
        puzzleSlots = FindObjectsOfType<PuzzleSlot>();
    }

    void Update()
    {
        if(isInteracting && !solved)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                cameraFollow.Unfocus();
                isInteracting = false;
                GetComponent<Collider>().enabled = true;
                FindObjectOfType<PointAndClick>().SetPause(false);
                foreach(DraggablePiece piece in FindObjectsOfType<DraggablePiece>())
                {
                    Destroy(piece.gameObject);
                }
            }
            if (CheckSlots())
            {
                solved = true;
            }
        }
        else if (isInteracting)
        {
            key.active = true;
            cameraFollow.Unfocus();
            isInteracting = false;
            FindObjectOfType<PointAndClick>().SetPause(false);
            foreach (DraggablePiece piece in FindObjectsOfType<DraggablePiece>())
            {
                piece.transform.parent = transform;
                Destroy(piece);
            }
            foreach (Collider collider in GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }
        }
    }

    public override void Interact()
    {
        if (!solved)
        {
            cameraFollow.Focus(gameObject, Vector3.up * 15.0f, false);
            FindObjectOfType<PointAndClick>().SetPause(true);
            isInteracting = true;
            GetComponent<Collider>().enabled = false;
            for (int i = 0; i < switchboard.puzzlePieces.Length; i++)
            {
                if(switchboard.puzzlePieces[i] && !pieces[i])
                {
                    GameObject obj = Instantiate(switchboard.puzzlePiecesInv[i].gameObject);
                    obj.AddComponent<DraggablePiece>().puzzleIndex = obj.GetComponent<PuzzlePiece>().puzzleIndex;
                    Destroy(obj.GetComponent<PuzzlePiece>());
                    obj.transform.localScale = new Vector3(50.0f, 50.0f, 50.0f);
                    obj.transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z) + ((Vector3.forward * i * 1.2f) + (Vector3.back * 5.0f)) + (Vector3.right * 5.0f) + (Vector3.up * 1.6f);
                    obj.GetComponent<Collider>().enabled = true;
                }
            }
        }
    }

    private bool CheckSlots()
    {
        foreach (PuzzleSlot puzzleSlot in puzzleSlots)
        {
            if (!puzzleSlot.solved)
            {
                return false;
            }
        }
        return true;
    }
}
