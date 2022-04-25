using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesControl : MonoBehaviour
{
    public GameObject Notes;
    public GameObject noteContent;
    public bool noteup = false;

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
        if (Input.GetKeyDown(KeyCode.O))
            {
                noteContent.GetComponent<TMPro.TextMeshProUGUI>().text = "Better Test /n wow";
            }
    }
}
