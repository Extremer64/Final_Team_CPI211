using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3UI : MonoBehaviour
{
    public GameObject PuzzleUI;
    public GameObject PuzzleNumber;
    private Switchboard switchboard;

    // Start is called before the first frame update
    void Start()
    {
        NotesControl.Puzzle = 7;
        switchboard = FindObjectOfType<Switchboard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchboard.CheckOneRitualPiece())
        {
            NotesControl.Puzzle = 8;
            PuzzleUI.SetActive(true);
        }

        if (switchboard.CheckRitualPieces())
        {
            NotesControl.Puzzle = 9;
        }

        int RitualPieces = switchboard.CountRitualPieces(switchboard.ritualPieces, true);
        PuzzleNumber.GetComponent<TMPro.TextMeshProUGUI>().text = ":" + RitualPieces + "/3";
    }
}
