using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    public Color color = Color.green;

    private Color[] colors;
    private Color[] startColors;
    private Renderer render;

    void Start()
    {
        render = GetComponent<Renderer>();
        startColors = new Color[render.materials.Length];
        for (int i = 0; i < startColors.Length; i++)
        {
            startColors[i] = render.materials[i].color;
        }
        colors = new Color[render.materials.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = render.materials[i].color / 2 + color / 2;
        }
    }

    void OnMouseEnter()
    {
        for (int i = 0; i < startColors.Length; i++)
        {
            render.materials[i].color += colors[i];
        }
    }

    void OnMouseExit()
    {
        for (int i = 0; i < render.materials.Length; i++)
        {
            render.materials[i].color = startColors[i];
        }
    }
}
