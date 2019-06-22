using UnityEngine;
public class CharacterMovement : MonoBehaviour {
    public float currentHeight = 40f; 
    public bool breaksEnabled = false;
    
    public float acceleration = 0.01f;
    public float heightBeforeBreak = 0f;
    public bool jetpackEnabled = false;
    public float characterHeight;

    void Awake() {
        characterHeight = transform.position.y;
    }

    public void moveWithGravity(float _maxSpeed, float _breakStrength) {
        // height & speed gain steadily increase
        currentHeight -= acceleration;
        if (acceleration + acceleration < _maxSpeed - acceleration && acceleration + acceleration > _maxSpeed - acceleration * - 1) acceleration += acceleration;
        transform.position = new Vector3(Time.frameCount, currentHeight, 0);
    }

    public void moveLikeAJetpack(float _gain) {
        characterHeight = characterHeight + _gain;
        transform.position = new Vector3(Time.frameCount, characterHeight, 0);
    }
}