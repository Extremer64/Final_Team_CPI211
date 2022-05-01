using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2UI : MonoBehaviour
{

    public GameObject PuzzleUI;

    // Start is called before the first frame update
    void Start()
    {
        NotesControl.Puzzle = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(NotesControl.Puzzle == 5)
        {
            PuzzleUI.SetActive(true);
        }
    }
}