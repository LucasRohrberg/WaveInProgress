using UnityEngine.UI;
using UnityEngine;
public class PointManager : MonoBehaviour {
    private float startTime;
    private int activePoints = 0;
    private float totalPoints;
    public Text score;

    void Awake() {
        startTime = Time.time;
    }
    public float calculatePoints() {
        totalPoints = (((Time.time - startTime) + activePoints) * FindObjectOfType<AudioManager>().heightModifier)*10;
        return totalPoints;
    }

    void Update() {
        if (FindObjectOfType<GameManager>().gameHasEnded == false) {
            score.text = calculatePoints().ToString("0");
        }
    }
}
