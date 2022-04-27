using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelPoint : MonoBehaviour
{
    public Vector3 returnPos = new Vector3(0, -200, 0);

    public PlayerHandler player;

    private bool isActive = false;

    void Start()
    {
        player = FindObjectOfType<PlayerHandler>();
    }

    public bool GetActive()
    {
        return isActive;
    }

    public void SetActive()
    {
        isActive = true;
        player.AddPoint(GetComponent<TravelPoint>());
    }

    public void SetInactive()
    {
        isActive = false;
        transform.localPosition = returnPos;
    }
}
