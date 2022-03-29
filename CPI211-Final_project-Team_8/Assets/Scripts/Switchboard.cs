using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Switchboard : MonoBehaviour
{
    [Header("Objects")]
    public GameObject player;
    private AudioSource musicSource;
    private AudioSource[] audioSources;
    private ChangeByScare[] scareChangables;

    [Header("Switches")]
    public bool puzzleOne = false;
    public bool puzzleTwo = false;
    public bool puzzleThree = false;

    [Header("Variables")]
    [Range(0.0f, 1.0f)]
    public float scareFactor = 0.0f;
    private float lastScareFactor = 0.0f;
    [Range(0.0f, 1.0f)]
    public float audioVolume = 1.0f;
    private float lastVolume = 1.0f;

    void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        audioSources = FindObjectsOfType<AudioSource>();
        scareChangables = FindObjectsOfType<ChangeByScare>();
    }

    void Update()
    {
        if (!scareFactor.Equals(lastScareFactor))
        {
            UpdateScare(scareFactor);
            lastScareFactor = scareFactor;
        }
        if (!audioVolume.Equals(lastVolume))
        {
            UpdateVolume(audioVolume);
            lastVolume = audioVolume;
        }
    }

    void UpdateScare(float newScareFactor)
    {
        foreach (ChangeByScare change in scareChangables)
        {
            change.scareFactor = newScareFactor;
        }
    }
    
    void UpdateVolume(float newVolume)
    {
        foreach (AudioSource audio in audioSources)
        {
            audio.volume = newVolume;
        }
    }
}