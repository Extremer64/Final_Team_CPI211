using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropoff : MonoBehaviour
{
    public ItemHandler.ItemType itemType;

    public bool completed = false;

    private GameObject pickedUp;

    void Update()
    {
        if(pickedUp != null)
        {
            if (pickedUp.transform.parent != transform)
            {
                if (pickedUp.GetComponentInParent<ItemPickup>())
                {
                    pickedUp.GetComponentInParent<ItemPickup>().Dropoff(transform);
                }
                else
                {
                    pickedUp.transform.parent = transform;
                    pickedUp.GetComponent<Rigidbody>().isKinematic = true;
                    pickedUp.GetComponent<Collider>().isTrigger = true;
                }
                pickedUp.transform.parent = transform;
                completed = true;
            }
            if (completed)
            {
                pickedUp.transform.localPosition = Vector3.Lerp(pickedUp.transform.localPosition, Vector3.zero, Time.deltaTime * 4);
                pickedUp.transform.rotation = Quaternion.Slerp(pickedUp.transform.rotation, Quaternion.identity, Time.deltaTime * 4);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ItemHandler>(out ItemHandler itemHandler))
        {
            if(itemHandler.itemType == itemType)
            {
                if(pickedUp == null)
                {
                    pickedUp = other.gameObject;
                }
            }
        }
    }
}
