using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    public Color color = Color.yellow;

    private Color startColor;
    private Renderer render;

    void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
    }

    void Update()
    {
        if (Time.timeScale == 0.0f)
        {
            render.material.color = startColor;
        }
    }

    void OnMouseEnter()
    {
        if(Time.timeScale > 0.0f)
        {
            Debug.Log(gameObject + ", " + color);
            startColor = render.material.color;
            render.material.color = color;
        }

    }

    void OnMouseExit()
    {
        render.material.color = startColor;
    }
}
