using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followAI : MonoBehaviour
{
    public Transform Player;
    public GameObject p;
    int MoveSpeed = 4;
    int MinDist = 0;




    void Start()
    {
        Player = FindObjectOfType<PlayerHandler>().transform;
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }
}
