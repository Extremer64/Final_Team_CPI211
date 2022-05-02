using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onCollisionReload : MonoBehaviour
{
    private AudioSource[] source;
    private AudioSource Death;
    private bool death;

    private void Start()
    {
        source = GetComponents<AudioSource>();
        Death = source[1];
        Death.loop = false;
    }
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Test Col");
        if(collision.gameObject.tag == "Enemy") 
        {
            Death.Play();
            death = true;
        }
        else if(collision.gameObject.tag == "Sphere")
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    private void Update()
    {
        if (!Death.isPlaying && death)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
