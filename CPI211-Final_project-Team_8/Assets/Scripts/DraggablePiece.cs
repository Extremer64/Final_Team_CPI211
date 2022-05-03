using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggablePiece : MonoBehaviour
{
    public int puzzleIndex;

    private bool isDragging = false;
    private Vector3 screenPoint;

    void Update()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = new Vector3(curPosition.x, transform.position.y, curPosition.z);
        }
    }
}
