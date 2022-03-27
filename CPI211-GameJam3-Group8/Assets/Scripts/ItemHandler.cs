using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public enum ItemType {Egg, Rice, Shrimp};

    public ItemType itemType;

    public Transform defaultParent;
    public Material defaultMaterial;
    public Material highlightMaterial;

    public float spoilage = 0.0f;
    public float spoilRate = 0.1f;

    void Awake()
    {
        defaultParent = GetComponentInParent<ItemStation>().transform;
    }

    void Update()
    {
        if(transform.localPosition.y > -0.35 && transform.localScale.magnitude > 0)
        {
            spoilage += Time.deltaTime * spoilRate;
        }
        transform.localScale -= Vector3.one * spoilage;
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
