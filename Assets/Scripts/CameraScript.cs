using UnityEngine;
public class CameraScript : MonoBehaviour {
    public AudioManager _audioManager;
    public CharacterMovement _character;

    void Update() {
        // tracks the player
        transform.position = new Vector3(Time.frameCount, _character.transform.position.y, -10);
    }

}