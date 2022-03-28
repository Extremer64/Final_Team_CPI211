using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private GameObject pickedUp;
    private LLStack<GameObject> grabable = new LLStack<GameObject>();

    void Update()
    {
        if (Input.GetKey(KeyCode.E) || Input.GetMouseButton(0))
        {
            if(grabable.Count != 0)
            {
                pickedUp = grabable.Pop();
                pickedUp.GetComponent<ItemHandler>().Default();
            }
        }
        else if(pickedUp != null)
        {
            pickedUp.transform.parent = pickedUp.GetComponent<ItemHandler>().defaultParent;
            pickedUp.GetComponent<Rigidbody>().isKinematic = false;
            pickedUp.GetComponent<Collider>().isTrigger = false;
            pickedUp = null;
        }
        if (pickedUp != null && pickedUp.transform.parent != transform)
        {
            pickedUp.transform.parent = transform;
            pickedUp.GetComponent<Rigidbody>().isKinematic = true;
            pickedUp.GetComponent<Collider>().isTrigger = true;
        }

        foreach (ItemHandler item in GetComponentsInChildren<ItemHandler>())
        {
            if(item.gameObject != pickedUp)
            {
                item.transform.parent = pickedUp.GetComponent<ItemHandler>().defaultParent;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Collider>().isTrigger = false;
            }
        }
    }

    public void Dropoff(Transform dropoff)
    {
        pickedUp.transform.parent = dropoff;
        pickedUp.GetComponent<Rigidbody>().isKinematic = true;
        pickedUp.GetComponent<Collider>().isTrigger = true;
        pickedUp = null;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<ItemHandler>(out ItemHandler itemHandler) && !grabable.Contains(collision.gameObject))
        {
            itemHandler.Highlight();
            grabable.Push(collision.gameObject);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ItemHandler>(out ItemHandler itemHandler) && grabable.Contains(collision.gameObject))
        {
            itemHandler.Default();
            grabable.Remove(collision.gameObject);
        }
    }
}
