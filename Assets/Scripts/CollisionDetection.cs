using UnityEngine;
public class CollisionDetection : MonoBehaviour {
    public PlayerMovement _playerMovement;
    public PointManager _pointManager;
    public LivesManager _livesManager;
    private bool subtractionCooldown = false;

    void Awake() {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _pointManager = FindObjectOfType<PointManager>();
        _livesManager = FindObjectOfType<LivesManager>();
    }
    void OnCollisionEnter(Collision collisionInfo) {
        // subtracts a life whenever the player hits a terrain cube, sets the collision on a short cooldown
        if (collisionInfo.collider.name == "Cube(Clone)" && subtractionCooldown == false) {
            if (_livesManager.lives > 1) {
                subtractionCooldown = true;
                print(subtractionCooldown);
                _livesManager.lives--;
                _pointManager.activePoints -= 6 * FindObjectOfType<AudioManager>().heightModifier;
                Invoke("resetCooldown", 1f);
                FindObjectOfType<CharacterMovement>().characterHeight = FindObjectOfType<AudioManager>().averageSpectrum() + (FindObjectOfType<AudioManager>().distanceBetweenWaves / 2);
                return;
            } else if (_livesManager.lives == 1) {
                print(subtractionCooldown);
                _playerMovement.enabled = false;
                FindObjectOfType<GameManager>().endGame();
            }
        }

        if (transform.name == "Milk") {
            // grants bonus points
            _pointManager.activePoints += 3 * FindObjectOfType<AudioManager>().heightModifier;
            Destroy(transform.parent.gameObject);
        }

        if (transform.name == "Fish") {
            // restores lives
            if (_livesManager.lives < 3) {
                _livesManager.lives ++;
            }
            Destroy(transform.parent.gameObject);
        }
    }

    void resetCooldown() {
        subtractionCooldown = false;
    }
}
