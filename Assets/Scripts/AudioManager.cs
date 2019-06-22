using UnityEngine.Audio;
using System;
using UnityEngine;
// Original code for Awake(), Start() & Play() by Brackeys, adapted & changed by Lucas Rohrberg
public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    public GameObject myPrefab;
    public int sampleRate = 8192;
    [Range(1f, 10f)] public int sampleQuality = 1;
    [Range(1f, 10f)] public int heightModifier = 3;
    private float currentSpectrum;
    public int distanceBetweenWaves = 50;
    void Awake() {
        // paste user chosen settings to the AudioSource component
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.spatialBlend = s.spatialBlend;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start() {
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    void Update() {
        turnSpectrumIntoTerrain();
    }
    public void Play (string name) {
        // iterates over the sounds array and plays the file thats name equals the requested file
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound file: " + name + " was not found!");
            return;
        }
        s.source.Play();
    }

    public float averageSpectrum() {
        // samples through the provided AudioClip of the AudioListener, the height then gets cut & floored to an average
        float waveHeight = 0;
        float[] audioSpectrum = new float[sampleRate];
        AudioListener.GetSpectrumData(audioSpectrum, 0, FFTWindow.BlackmanHarris);
        for (int i = 1; i < audioSpectrum.Length; i++) {
            waveHeight += (float)Math.Floor(Mathf.Clamp(audioSpectrum[i]*10000, 0, 20));  
        }
        return waveHeight/(sampleRate/heightModifier);   
    }

    public void turnSpectrumIntoTerrain() {
        // creates cubes that are distanceBetweenWaves-far apart
        for (int i = 0; i < sampleQuality; i++) {
            Instantiate(myPrefab, new Vector3(Time.frameCount+90, averageSpectrum() - 50, 20), Quaternion.identity);
            Instantiate(myPrefab, new Vector3(Time.frameCount+90, averageSpectrum() + distanceBetweenWaves * 2, 20), Quaternion.identity);
        }
    }
}
