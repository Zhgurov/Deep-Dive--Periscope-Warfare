using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private Audio[] soundAudios, misicAudios, effectAudios;
    [SerializeField] private AudioSource soundSource, misicSource, effectSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public void PlaySound(string _soundName, bool isPlayOneShot)
    {
        Audio currentAudio = Array.Find(soundAudios, x => x.NameAudio == _soundName);

        if (currentAudio == null)
            print("No sound!");
        else
        {
            if (isPlayOneShot)
                soundSource.PlayOneShot(currentAudio.AudioClip);
            else
            {
                soundSource.clip = currentAudio.AudioClip;
                soundSource.Play();
            }
        }
    }

    public void PlayMisic(string _soundName)
    {
        Audio currentAudio = Array.Find(misicAudios, x => x.NameAudio == _soundName);

        if (currentAudio == null)
            print("No sound!");
        else
        {
            misicSource.Stop();
            misicSource.clip = currentAudio.AudioClip;
            misicSource.Play();
        }
    }

    public void PlayEffect(string _soundName)
    {
        Audio currentAudio = Array.Find(effectAudios, x => x.NameAudio == _soundName);

        if (currentAudio == null)
            print("No sound!");
        else
            effectSource.PlayOneShot(currentAudio.AudioClip);
    }

}
