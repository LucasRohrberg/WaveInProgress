using UnityEngine;
public class CollisionDetection : MonoBehaviour {
    public PlayerMovement _playerMovement;
    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.collider.name == "Cube(Clone)") {
            _playerMovement.enabled = false;
            FindObjectOfType<GameManager>().endGame();
        }
    }
}
