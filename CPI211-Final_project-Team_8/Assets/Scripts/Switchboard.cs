using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Switchboard : MonoBehaviour
{
    [Header("Objects")]
    public PlayerHandler player;

    public PuzzlePiece[] puzzlePiecesInv = new PuzzlePiece[9];

    private AudioSource[] audioSources;
    private ChangeByScare[] scareChangables;

    [Header("Switches")]
    public bool[] levelComplete = new bool[3];

    public bool testItem = false;

    public bool[] puzzlePieces = new bool[9];

    public bool[] ritualPieces = new bool[3];

    [Header("Variables")]
    [Range(0.0f, 1.0f)]
    public float scareFactor = 0.0f;
    private float lastScareFactor = 0.0f;
    [Range(0.0f, 1.0f)]
    public float audioVolume = 1.0f;
    private float lastVolume = 1.0f;

    void Awake()
    {
        player = FindObjectOfType<PlayerHandler>();
        audioSources = FindObjectsOfType<AudioSource>();
        scareChangables = FindObjectsOfType<ChangeByScare>();
        foreach(Interactable obj in FindObjectsOfType<Interactable>())
        {
            if (!TryGetComponent<Highlightable>(out Highlightable highlightable))
            {
                obj.gameObject.AddComponent<Highlightable>();
            }
        }
        foreach (NPC obj in FindObjectsOfType<NPC>())
        {
            if (!TryGetComponent<Highlightable>(out Highlightable highlightable))
            {
                obj.gameObject.AddComponent<Highlightable>();
            }
        }
        foreach (ItemHandler obj in FindObjectsOfType<ItemHandler>())
        {
            if (!TryGetComponent<Highlightable>(out Highlightable highlightable))
            {
                obj.gameObject.AddComponent<Highlightable>();
            }
        }
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

    public bool CheckOnePuzzlePiece()
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i])
            {
                return true;
            }
        }
        return false;
    }

    public int CountPieces(bool[] puzzlePieces, bool flag)
    {
        int count = 0;
        for(int i = 0; i < puzzlePieces.Length; i++)
        {
            if (puzzlePieces[i] == flag)
            {
                count++;
            }
        }
        return count;
    }

    public bool CheckRitualPieces()
    {
        foreach (bool rit in ritualPieces)
        {
            if (!rit)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckKey(int level)
    {
        return levelComplete[level];
    }
}