using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected string interactTag = "";
    public virtual void Interact()
    {
    }
    public string GetTag()
    {
        return interactTag;
    }
}
