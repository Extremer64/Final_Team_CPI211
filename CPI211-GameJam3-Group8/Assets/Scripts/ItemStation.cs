using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStation : MonoBehaviour
{
    public GameObject template;
    public Stack<GameObject> clones = new Stack<GameObject>();

    public float spawnDelay = 2.5f;

    private Vector3 scale;
    private float timer = 0.0f;

    void Start()
    {
        scale = template.transform.localScale;
        clones.Push(Instantiate(template, transform.position, transform.rotation, transform));
        Destroy(template);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
        {
            clones.Push(Instantiate(clones.Peek(), transform.position, transform.rotation, transform));
            clones.Peek().transform.localScale = scale;
            clones.Peek().GetComponent<Collider>().isTrigger = false;
        }

        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0.0f)
        {
            clones.Push(Instantiate(clones.Peek(), transform.position, transform.rotation, transform));
            clones.Peek().transform.localScale = scale;
            clones.Peek().GetComponent<Collider>().isTrigger = false;
            timer = 0.0f;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(clones.Peek()))
        {
            timer = spawnDelay;
        }
    }
}
