using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSystem : MonoBehaviour
{
    public GameObject Timer;
    [SerializeField] public float timer;
    [SerializeField] public static float minutes;
    [SerializeField] public static float seconds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        minutes = Mathf.Floor(timer / 60);
        seconds = Mathf.Floor(timer - (minutes * 60));
        if (minutes == 0 && seconds < 10)
        {
            Timer.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: 0:0" + seconds;
        }
        else if (minutes == 0 && seconds >= 10)
        {
            Timer.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: 0:" + seconds;
        }
        else if (minutes >= 1 && seconds < 10)
        {
            Timer.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: " + minutes + ":0" + seconds;
        }
        else
        {
            Timer.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: " + minutes + ":" + seconds;
        }

        if (timer <= 0)
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
