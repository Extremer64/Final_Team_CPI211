using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Line[] lines;
}

[System.Serializable]
public class Line
{
    public string[] line = { "TEXT" };
}