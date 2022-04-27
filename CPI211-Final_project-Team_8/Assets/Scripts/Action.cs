using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    protected string actionTag = "";
    public virtual void DoAction()
    {
    }
    public string GetTag()
    {
        return actionTag;
    }
}
