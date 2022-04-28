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
    public bool updatenotes = false;

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
            updatenotes = true;
        }
        else if (Puzzle != 1 && Input.GetKeyDown(KeyCode.P))
        {
            NotesControl.Puzzle = 1;
            updatenotes = true;
        }
            if (Puzzle == 0 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "TESTETTETETTETETETTETETTEVVFEVTFVYTFVYUTVEUVUEVFVTEUFVUEUYEVUYEF";
        }
        else if(Puzzle == 1 && updatenotes)
        {
            noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "You've woken up in your bed \nSomething isn't right\nMight as well take a look around";
        }

        }

        if(updatenotes == true)
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
