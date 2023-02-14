using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public static VoiceManager Instance;

    public AudioSource Puzzle1EntranceVoiceline;
    public AudioSource Puzzle1FlavorVoiceline1;
    public AudioSource Puzzle1FlavorVoiceline2;
    public AudioSource Puzzle1FlavorVoiceline3;
    public AudioSource Puzzle1ClueVoiceline1;
    public AudioSource Puzzle1ClueVoiceline2;
    public AudioSource Puzzle1ClueVoiceline3;
    public AudioSource Puzzle1CompletionVoiceline;

    public 
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public static void CallPuzzle1EntranceVoiceline()
    {
        VoiceManager.Instance.Puzzle1EntranceVoiceline.Play();
    }

    public static void CallPuzzle1FlavorVoiceline1()
    {
        VoiceManager.Instance.Puzzle1FlavorVoiceline1.Play();
    }

    public static void CallPuzzle1FlavorVoiceline2()
    {
        VoiceManager.Instance.Puzzle1FlavorVoiceline2.Play();
    }

    public static void CallPuzzle1FlavorVoiceline3()
    {
        VoiceManager.Instance.Puzzle1FlavorVoiceline3.Play();
    }

    public static void CallPuzzle1ClueVoiceline1()
    {
        VoiceManager.Instance.Puzzle1ClueVoiceline1.Play();
    }

    public static void CallPuzzle1ClueVoiceline2()
    {
        VoiceManager.Instance.Puzzle1ClueVoiceline2.Play();
    }

    public static void CallPuzzle1ClueVoiceline3()
    {
        VoiceManager.Instance.Puzzle1ClueVoiceline3.Play();
    }

    public static void CallPuzzle1CompletionVoiceline()
    {
        VoiceManager.Instance.Puzzle1CompletionVoiceline.Play();
    }
}
