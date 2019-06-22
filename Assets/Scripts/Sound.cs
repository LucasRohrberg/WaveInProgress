using UnityEngine.Audio;
using UnityEngine;
// Original code by Brackeys, adapted & changed by Lucas Rohrberg
[System.Serializable]
public class Sound {
    // basically a storage / database for the sound presets
    public string name;
    public AudioClip clip;
    public bool loop;
    [Range(0f, 1f)] public float spatialBlend = 0;
    [Range(0f, 1f)] public float volume = 1;
    [Range(0.1f, 3)] public float pitch = 1;

    public AudioSource source;
}
