using UnityEngine;
// PlayerInput
public class PlayerMovement : MonoBehaviour {
    public CharacterMovement controller;
    public float maxSpeed = 2f;
    public float breakStrength = 5f;
    private float startAcceleration;
    
    private float startJetpack;
    void Update() {
        useJetpack();
    }
    void Awake() {
        startAcceleration = controller.acceleration;
    }
    public void changeGravity() {
        // switches gravity whenever the player hits spacebar
        if (Input.GetKeyDown("space")) {
            if (controller.acceleration > 0) {
                controller.acceleration = startAcceleration * - 1;
            } else if (controller.acceleration < 0) {
                controller.acceleration = startAcceleration;
            }
        }
    }

    public void useJetpack() {
        // player gains height by holding spacebar, sinks when nothing is being pressed
        if (Input.GetKey("space")) {
            controller.moveLikeAJetpack(0.5f);
        } else {
            controller.moveLikeAJetpack(-0.5f);
        }
    }
}
