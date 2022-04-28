using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1UI : MonoBehaviour
{

    public GameObject PuzzleUI;
    public GameObject PuzzleNumber;


    // Start is called before the first frame update
    void Start()
    {
        NotesControl.Puzzle = 1;
        NotesControl.updatenotes = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
