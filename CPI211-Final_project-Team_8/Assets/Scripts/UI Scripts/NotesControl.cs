using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesControl : MonoBehaviour
{
    public GameObject Notes;
    public GameObject noteContent;
    public GameObject UpdateMessage;
    [SerializeField] public static int Puzzle;
    public bool noteup = false;
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
            NotesControl.updatenotes = true;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            NotesControl.Puzzle += 1;
            NotesControl.updatenotes = true;
        }
        if (Puzzle == 0 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "TESTETTETETTETETETTETETTEVVFEVTFVYTFVYUTVEUVUEVFVTEUFVUEUYEVUYEF";
        }
        else if(Puzzle == 1 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "You've woken up in your bed \nSomething isn't right\nMight as well take a look around\nMaybe Big Ted can help\nHe's always been there for you";
        }
        else if (Puzzle == 2 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "Puzzle Pieces...\nMaybe Completing the Puzzle will help\nThere seem to be a few lying around\nWhere is everyone";
        }
        else if (Puzzle == 3 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "You are definitely dreaming\nThis puzzle just gave you a key\nAt least this might be able to let you out of here";
        }
        else if (Puzzle == 4 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "Again\nSomething's different tho\nHopefully Big Ted will be useful like last time";
        }
        else if (Puzzle == 5 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "A Code huh?\nYou should Probably look around for more hints\nHints:";
        }
        else if (Puzzle == 6 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "You made it through that door\nNow something is VERY wrong here\n....Is that....an Accordian??";
        }
        else if (Puzzle == 7 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "Waking up here is getting tiring\nSomething is extremely wrong\nIs this a graveyard";
        }
        else if (Puzzle == 8 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "This place is much more dangerous than the last few\nYou need to get the right ingredients from those graves";
        }
        else if (Puzzle == 9 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "A KEY\nMaybe you can finally get out of here";
        }
        else if (Puzzle == 10 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "Run";
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
