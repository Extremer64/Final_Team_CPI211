using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifespanAI : MonoBehaviour
{
    public float sec = 5;

    void Start() {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct() {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
}
