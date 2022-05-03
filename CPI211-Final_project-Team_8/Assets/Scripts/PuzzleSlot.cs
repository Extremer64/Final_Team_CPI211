using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public int index;
    public bool solved = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<DraggablePiece>(out DraggablePiece puzzle))
        {
            if(index == puzzle.puzzleIndex)
            {
                solved = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<DraggablePiece>(out DraggablePiece puzzle))
        {
            if (index == puzzle.puzzleIndex)
            {
                solved = false;
            }
        }
    }
}
