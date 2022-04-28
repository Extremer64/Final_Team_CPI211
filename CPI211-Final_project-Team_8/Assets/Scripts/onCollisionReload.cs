using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onCollisionReload : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Test Col");
        if(collision.gameObject.tag == "Enemy") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
