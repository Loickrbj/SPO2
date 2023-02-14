using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public static VoiceManager Instance;

    public List<AudioClip> MainVoicelines;
    public List<AudioClip> FlavorVoicelines;
    public List<AudioClip> ClueVoicelines;

    private AudioSource audioSource;

    private int mainVoicelinesCount = 0;
    private int flavorVoicelinesCount = 0;
    private int clueVoicelinesCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        audioSource = transform.GetComponent<AudioSource>();
    }

    public static void CallMainVoiceline(bool skip)
    {
        if (VoiceManager.Instance.mainVoicelinesCount < VoiceManager.Instance.MainVoicelines.Count)
        {
            if (!skip)
            {
                VoiceManager.Instance.audioSource.clip = VoiceManager.Instance.MainVoicelines[VoiceManager.Instance.mainVoicelinesCount];
                VoiceManager.Instance.audioSource.Play();
            }
            ++VoiceManager.Instance.mainVoicelinesCount;
        }
    }

    public static void CallFlavorVoiceline(bool skip)
    {
        if (VoiceManager.Instance.flavorVoicelinesCount < VoiceManager.Instance.FlavorVoicelines.Count)
        {
            if (!skip)
            {
                VoiceManager.Instance.audioSource.clip = VoiceManager.Instance.FlavorVoicelines[VoiceManager.Instance.flavorVoicelinesCount];
                VoiceManager.Instance.audioSource.Play();
            }
            ++VoiceManager.Instance.flavorVoicelinesCount;
        }
    }

    public static void CallClueVoiceline(bool skip)
    {
        if (VoiceManager.Instance.clueVoicelinesCount < VoiceManager.Instance.ClueVoicelines.Count)
        {
            if (!skip)
            {
                VoiceManager.Instance.audioSource.clip = VoiceManager.Instance.ClueVoicelines[VoiceManager.Instance.clueVoicelinesCount];
                VoiceManager.Instance.audioSource.Play();
            }
            ++VoiceManager.Instance.clueVoicelinesCount;
        }
    }

}
