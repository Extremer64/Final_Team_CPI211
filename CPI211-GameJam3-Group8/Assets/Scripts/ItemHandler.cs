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

    void Awake()
    {
        defaultParent = GetComponentInParent<ItemStation>().transform;
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
