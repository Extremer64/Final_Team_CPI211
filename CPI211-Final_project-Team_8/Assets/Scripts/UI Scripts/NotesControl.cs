using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesControl : MonoBehaviour
{
    public GameObject Notes;
    public GameObject noteContent;
    public GameObject UpdateMessage;
    [SerializeField] public static int Puzzle;
    public static int LastPuzzle;
    public bool noteup = true;
    public static bool updatenotes = false;

    public bool Notemessage = false;
    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!noteup && Input.GetKeyDown(KeyCode.N))
            {
                Notes.SetActive(true);
                noteup = true;
            }
        else if (noteup && Input.GetKeyDown(KeyCode.N))
            {
                Notes.SetActive(false);
                noteup = false;
            }
        if (Puzzle != 0 && Input.GetKeyDown(KeyCode.O))
        {
            NotesControl.Puzzle = 0;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            NotesControl.Puzzle += 1;
        }

        if (LastPuzzle != Puzzle)
        {
            updatenotes = true;
            LastPuzzle = Puzzle;
        }

        if (Puzzle == 0 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "TESTETTETETTETETETTETETTEVVFEVTFVYTFVYUTVEUVUEVFVTEUFVUEUYEVUYEF";
        }
        else if(Puzzle == 1 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "I've woken up in my bed \nSomething isn't right\nMight as well take a look around\nMaybe Big Ted can help\nHe's always been there for me";
        }
        else if (Puzzle == 2 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "Puzzle Pieces...\nThere seem to be a few lying around\nWhere is everyone?";
        }
        else if (Puzzle == 3 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "Well thats all the pieces...\nMaybe Completing that puzzle will do something\nIt certainly seems to be weird sitting in the room like that...";
        }
        else if (Puzzle == 4 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "Waking up again....\nSomething's different tho\nHopefully Big Ted will be useful like last time";
        }
        else if (Puzzle == 5 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "I don't remember a keypad being here\nOh well, I should Probably look around for more hints";
        }
        else if (Puzzle == 6 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "I made it through that door\nNow something is VERY wrong here\n....Is that sound....a Parrot??\nI guess this is a pirate ship...\nBut why are there so many doors?";
        }
        else if (Puzzle == 7 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "Waking up here is getting tiring\nSomething is extremely wrong\nIs this a graveyard??\nThere was a shovel next to my bed...";
        }
        else if (Puzzle == 8 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "This place is much more dangerous than the last few\nI did find some piece in that grave but it is kind of disgusting digging up graves,\nbut I guess you gotta do what you gotta do in this strange world";
        }
        else if (Puzzle == 9 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "The Pieces seem to take the shape of a key\nNot exactly sure how to put them together\nIf I can maybe I can finally get out of here";
        }
        else if (Puzzle == 10 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "I need to get out of here";
        }

        if (updatenotes == true)
        {
            updatenotes = false;
            Notemessage = true;
            UpdateMessage.SetActive(true);
            Timer = 3;
        }

        if(Notemessage == true)
        {
            if (Timer <= 0)
            {
                UpdateMessage.SetActive(false);
                Notemessage = false;
            }
            Timer -= Time.deltaTime;
        }


    }
}
