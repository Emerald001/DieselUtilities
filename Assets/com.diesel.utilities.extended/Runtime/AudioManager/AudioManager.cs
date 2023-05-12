using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private readonly List<Sound> soundslist = new();

    public void Init() {
        foreach (Sound s in soundslist) {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.clip;

            s.Source.volume = s.volume;
            s.Source.pitch = s.pitch;
            s.Source.loop = s.loop;

            s.Source.spatialBlend = s.spacialBlend;
        }
    }

    public void PlayAudio(string name) => soundslist.Find(sound => sound.name == name)?.Source.Play();

    public void PlayLoopedAudio(string name, bool onOrOff) {
        if (onOrOff)
            soundslist.Find(sound => sound.name == name)?.Source.Play();
        else
            soundslist.Find(sound => sound.name == name)?.Source.Stop();
    }
}

[System.Serializable]
public class Sound {
    public AudioSource Source { get; set; }

    [Header("Audio")]
    public string name;
    public AudioClip clip;

    [Header("Audio Settings")]
    [Range(0, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    [Range(0, 1f)]
    public float spacialBlend;
    public bool loop;
}
