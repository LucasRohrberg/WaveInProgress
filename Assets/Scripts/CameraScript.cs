using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraScript : MonoBehaviour {
    public AudioManager _audioManager;
    private float[] cameraPosition = new float[2];
    private float _averageSpectrum;
    public float yVelocity = 0.0f;
    public float smoothTime = 0.02f;

    void Update() {
        StartCoroutine("getCameraData");
        StartCoroutine("moveCamera");
    }

    IEnumerator getCameraData() {
        _averageSpectrum = (_audioManager.averageSpectrum()+(_audioManager.averageSpectrum()+50))/2;
        cameraPosition[0] = cameraPosition[1];
        cameraPosition[1] = _averageSpectrum;
        yield return new WaitForSeconds(2f); // y u no work?
    }

    IEnumerator moveCamera() {
        float cameraHeightDifference = Mathf.Clamp(cameraPosition[1] - cameraPosition[0], -1, 1);
        // float newPosition = Mathf.Clamp(Mathf.SmoothDamp(cameraPosition[0], cameraPosition[0] + cameraHeightDifference / 2, ref yVelocity, smoothTime), 30, 40);
        transform.position = new Vector3(Time.frameCount, 50, -50);
        yield return null;
    }
}