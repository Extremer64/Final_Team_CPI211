using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followAI2 : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 4;
    int MinDist = 10;




    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }
}
