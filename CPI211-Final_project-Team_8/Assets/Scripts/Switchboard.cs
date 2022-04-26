using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Switchboard : MonoBehaviour
{
    [Header("Objects")]
    public PlayerHandler player;

    public PuzzlePiece[] puzzlePiecesInv = new PuzzlePiece[9];

    private AudioSource musicSource;
    private AudioSource[] audioSources;
    private ChangeByScare[] scareChangables;

    [Header("Switches")]
    public bool[] levelComplete = new bool[3];

    public bool testItem = false;

    public bool[] puzzlePieces = new bool[9];

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
        player = FindObjectOfType<PlayerHandler>();
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

    public bool CheckPuzzlePieces()
    {
        foreach(bool puz in puzzlePieces)
        {
            if (!puz)
            {
                return false;
            }
        }
        return true;
    }
}