using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStation : MonoBehaviour
{

    public GameObject template;
    public Stack<GameObject> clones = new Stack<GameObject>();

    public float spawnDelay = 2.5f;
    public bool cooked = false;

    private Vector3 scale;
    private float timer = 0.0f;
    private ItemDropoff[] collectionPoints;
    private AudioSource fooddone;

    void Start()
    {
        scale = template.transform.localScale;
        clones.Push(Instantiate(template, transform.position, transform.rotation, transform));
        Destroy(template);
        collectionPoints = FindObjectsOfType<ItemDropoff>();
        int nonRicePoints = 0;
        for (int i = 0; i < collectionPoints.Length; i++)
        {
            if (collectionPoints[i].itemType != ItemHandler.ItemType.FriedRice)
            {
                collectionPoints[nonRicePoints] = collectionPoints[i];
                nonRicePoints++;
            }
        }
        System.Array.Resize<ItemDropoff>(ref collectionPoints, nonRicePoints);
        fooddone = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
        {
            clones.Push(Instantiate(clones.Peek(), transform.position, transform.rotation, transform));
            clones.Peek().transform.localScale = scale;
            clones.Peek().GetComponent<Collider>().isTrigger = false;
        }

        int completed = 0;
        foreach (ItemDropoff itemStation in collectionPoints)
        {
            if (itemStation.completed)
            {
                completed++;
            }
        }

        if (completed == collectionPoints.Length && !cooked)
        {
            timer = 0.01f;
            cooked = true;
            fooddone.Play();
        }
        else if (!cooked)
        {
            clones.Peek().transform.position = Vector3.one * -10.0f;
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
