using UnityEngine.UI;
using UnityEngine;
public class LivesManager : MonoBehaviour
{
    public int lives = 1;
    public Text textField;

    void Update() {
        textField.text = "Lives: " + lives.ToString("0");
    }
}
