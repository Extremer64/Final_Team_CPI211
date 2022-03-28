using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public enum ItemType {Egg, Rice, Onion, Pepper, Shrimp};

    public ItemType itemType;

    public Transform defaultParent;
    public Material defaultMaterial;
    public Material highlightMaterial;

    public float spoilage = 0.0f;
    public float spoilRate = 0.1f;

    void Update()
    {
        if(transform.localPosition.y < -0.35)
        {
            spoilage += Time.deltaTime * spoilRate;
        }
    }

    public void Highlight()
    {
        GetComponent<MeshRenderer>().material = highlightMaterial;
    }

    public void Default()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }
}
