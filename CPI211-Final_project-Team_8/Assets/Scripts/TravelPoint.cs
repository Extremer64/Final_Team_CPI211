using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelPoint : MonoBehaviour
{
    private bool isActive = false;

    public PlayerHandler player;

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
        transform.localPosition = Vector3.zero;
    }
}
