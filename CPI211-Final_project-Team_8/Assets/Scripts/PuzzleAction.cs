using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAction : Action
{
    public PuzzlePiece piece;
    public Vector3 newPos;

    private bool isActive = false;

    void Start()
    {
        actionTag = "BearPuzzlePiece";
    }

    void Update()
    {
        if (isActive && piece.transform.position.y > -10)
        {
            piece.transform.position = Vector3.Lerp(piece.transform.position, newPos, Time.deltaTime);
        }
    }

    public override void DoAction()
    {
        isActive = true;
    }
}
