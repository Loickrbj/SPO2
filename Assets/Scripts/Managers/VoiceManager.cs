using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public static VoiceManager Instance;

    public AudioSource VoicelineSource;

    public List<AudioClip> MainVoicelines;
    public List<AudioClip> FlavorVoicelines;
    public List<AudioClip> ClueVoicelines;

    private int mainVoicelinesCount = 0;
    private int flavorVoicelinesCount = 0;
    private int clueVoicelinesCount = 0;

    private void Start()
    {
        Instance = this;
    }

    public static void CallMainVoiceline(bool skip)
    {
        if (Instance.mainVoicelinesCount < Instance.MainVoicelines.Count)
        {
            if (!skip)
            {
                Instance.VoicelineSource.clip = Instance.MainVoicelines[Instance.mainVoicelinesCount];
                Instance.VoicelineSource.Play();
            }
            Instance.mainVoicelinesCount++;
        }
    }

    public static void CallFlavorVoiceline(bool skip)
    {
        if (Instance.flavorVoicelinesCount < Instance.FlavorVoicelines.Count)
        {
            if (!skip)
            {
                Instance.VoicelineSource.clip = Instance.FlavorVoicelines[Instance.flavorVoicelinesCount];
                Instance.VoicelineSource.Play();
            }
            Instance.flavorVoicelinesCount++;
        }
    }

    public static void CallClueVoiceline(bool skip)
    {
        if (Instance.clueVoicelinesCount < Instance.ClueVoicelines.Count)
        {
            if (!skip)
            {
                Instance.VoicelineSource.clip = Instance.ClueVoicelines[Instance.clueVoicelinesCount];
                Instance.VoicelineSource.Play();
            }
            Instance.clueVoicelinesCount++;
        }
    }
}
