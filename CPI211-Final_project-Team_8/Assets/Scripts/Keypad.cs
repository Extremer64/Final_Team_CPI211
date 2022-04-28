using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad : Interactable
{
    public bool solved = false;
    public int solution;

    public GameObject[] displayAndButtons = new GameObject[10];

    private bool isInterracting = false;

    private CameraFollow cameraFollow;
    private RaycastHit hit;
    private int input;
    private float delay = 0.0f;
    private float clickDelay;

    void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    void Update()
    {
        if (isInterracting && !solved)
        {
            if (delay < 2.5f)
            {
                delay += Time.unscaledDeltaTime;
            }
            else
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    cameraFollow.Unfocus();
                    isInterracting = false;
                    GetComponent<Collider>().enabled = true;
                }
            }
            if (Input.GetMouseButton(0) && !solved)
            {
                if (clickDelay > 0.125f)
                {
                    if (Physics.Raycast(cameraFollow.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit))
                    {
                        for (int i = 0; i < displayAndButtons.Length; i++)
                        {
                            if (displayAndButtons[i] == hit.transform.gameObject)
                            {
                                input *= 10;
                                input += i;
                            }
                        }
                        displayAndButtons[0].GetComponent<TextMeshPro>().text = RenderNumpad(input);
                        if(input == solution)
                        {
                            displayAndButtons[0].GetComponent<TextMeshPro>().color = Color.green;
                            solved = true;
                        }
                    }
                }
                clickDelay = 0.0f;
            }
            if(clickDelay < 0.125)
            {
                clickDelay += Time.unscaledDeltaTime;
            }
        }
        else if (isInterracting)
        {
            cameraFollow.Unfocus();
            isInterracting = false;
            foreach(Collider collider in GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }
        }
    }

    public override void Interact()
    {
        if (!solved)
        {
            cameraFollow.Focus(gameObject, Vector3.right * 2.0f);
            isInterracting = true;
            delay = 0.0f;
            GetComponent<Collider>().enabled = false;
        }
    }

    private string RenderNumpad(int inputNum)
    {
        if (inputNum > 99999)
        {
            input = 0;
            return "- - - - -";
        }
        else if(inputNum < 1)
        {
            return "- - - - -";
        }
        while (inputNum < 9999)
        {
            inputNum *= 10;
        }
        string temp = "";
        while (temp.Length < 10)
        {
            if(temp.EndsWith(" "))
            {
                if(inputNum.ToString().ToCharArray()[temp.Length / 2] == '0')
                {
                    temp += "-";
                }
                else
                {
                    temp += inputNum.ToString().ToCharArray()[temp.Length / 2];
                }
            }
            else
            {
                temp += " ";
            }
        }
        return temp;
    }
}
