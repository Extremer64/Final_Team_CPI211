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
    public float timetoreset;
    public bool Lose;
    private AudioSource[] music;
    private AudioSource background;
    private AudioSource lose;

    // Start is called before the first frame update
    void Start()
    {
        timetoreset = 5;
        Lose = false;
        music = GetComponents<AudioSource>();
        background = music[0];
        lose = music[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
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
        }
        if (timer <= 0 && !Lose)
        {
            Lose = true;
            timer = 0;
            minutes = 0;
            seconds = 0;
            background.Stop();
            lose.Play();
        }

        else if (Lose)
        {
            timetoreset -= Time.deltaTime;
        }

        if (timetoreset <= 0)
        {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
        }
    }
}