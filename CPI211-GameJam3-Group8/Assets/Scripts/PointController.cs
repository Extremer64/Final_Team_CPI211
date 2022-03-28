using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI counter;
    public AudioSource finishAudio;

    public int scene;

    private DeliveryStation[] deliveryPoints;
    private bool waiting = false;

    void Start()
    {
        deliveryPoints = FindObjectsOfType<DeliveryStation>();
    }

    void Update()
    {
        int tracker = 0;
        foreach (DeliveryStation point in deliveryPoints)
        {
            if (point.completed)
            {
                tracker++;
            }
        }
        counter.text = tracker + "/" + deliveryPoints.Length;
        if (tracker == deliveryPoints.Length && !waiting)
        {
            finishAudio.Play();
        }
        if(!waiting && finishAudio.isPlaying)
        {
            waiting = true;
        }
        if(!finishAudio.isPlaying && waiting)
        {
            SceneManager.LoadScene(scene + 1);
        }
    }
}
