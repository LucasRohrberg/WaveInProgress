using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public bool gameHasEnded = false;
    public float restartDelay = 2f;
    public void endGame() {
        // sets the game status to game over
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Invoke("restart", restartDelay); 
        }
    }

    void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
