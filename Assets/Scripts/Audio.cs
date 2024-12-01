using UnityEngine;

[System.Serializable]
public class Audio
{
    [field: SerializeField] public string NameAudio { get; private set; }
    [field: SerializeField] public AudioClip AudioClip { get; private set; }
}
