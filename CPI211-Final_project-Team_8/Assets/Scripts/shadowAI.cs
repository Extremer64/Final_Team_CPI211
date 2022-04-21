using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shadowAI : MonoBehaviour
{
    public Vector3 vel = new Vector3(-1,0,0);
    // Update is called once per frame
    void Update()
    {
        transform.Translate(vel * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        print("Collide");
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Hallway");
        }
    }
}
