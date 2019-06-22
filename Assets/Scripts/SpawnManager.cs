using UnityEngine;
public class SpawnManager : MonoBehaviour {
    private float randomNumber;
    public GameObject milk;
    public GameObject fish;
    public AudioManager _audiomanager;
    public int itemDensity = 500;

    void FixedUpdate() {
        if (Time.frameCount % (itemDensity * 6) == 0) {
            randomNumber = Random.value * (_audiomanager.distanceBetweenWaves - 10) + 5;
            Instantiate(fish, new Vector3(Time.frameCount+90, _audiomanager.averageSpectrum() + randomNumber, 0), Quaternion.identity);
            return;
        } else if (Time.frameCount % itemDensity == 0) {
            randomNumber = Random.value * (_audiomanager.distanceBetweenWaves - 10) + 5;
            Instantiate(milk, new Vector3(Time.frameCount+90, _audiomanager.averageSpectrum() + randomNumber, 0), Quaternion.identity);
            return;
        }
    }
}
