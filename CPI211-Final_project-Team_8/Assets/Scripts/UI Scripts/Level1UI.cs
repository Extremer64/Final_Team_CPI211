using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1UI : MonoBehaviour
{

    public GameObject PuzzleUI;
    public GameObject PuzzleNumber;
    private Switchboard switchboard;


    // Start is called before the first frame update
    void Start()
    {
        NotesControl.Puzzle = 1;
        switchboard = FindObjectOfType<Switchboard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchboard.CheckOnePuzzlePiece())
        {
            NotesControl.Puzzle = 2;
            PuzzleUI.SetActive(true);
        }
        
        if (switchboard.CheckPuzzlePieces())
        {
            NotesControl.Puzzle = 3;
        }

        int PuzzlePieces = switchboard.CountPieces(switchboard.puzzlePieces, true);
        PuzzleNumber.GetComponent<TMPro.TextMeshProUGUI>().text = ":" + PuzzlePieces + "/9";
    }
}
