using UnityEngine.UI;
using UnityEngine;
public class PointManager : MonoBehaviour {
    private float startTime;
    public int activePoints = 0;
    private float totalPoints;
    private float scoreModifier;
    public Text textField;
    void Awake() {
        // saves the time for point calculation & calculates a scoreModifier using the current settings
        startTime = Time.time;
        scoreModifier = (FindObjectOfType<AudioManager>().heightModifier * 2) - (FindObjectOfType<AudioManager>().distanceBetweenWaves / 10);
        if (scoreModifier < 1) { 
            scoreModifier = 1;
        }
        if (scoreModifier > 10) {
            scoreModifier = 10;
        }
    }
    public float calculatePoints() {
        // generates the score
        totalPoints = (((Time.time - startTime) + activePoints) * scoreModifier)*10;
        return totalPoints;
    }

    void Update() {
        // displays the score
        if (FindObjectOfType<GameManager>().gameHasEnded == false) {
            textField.text = "Score: " + calculatePoints().ToString("0");
        }
    }
}
