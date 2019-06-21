using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// PlayerInput
public class PlayerMovement : MonoBehaviour
{
    public CharacterMovement controller;
    public float maxSpeed = 2f;
    public float breakStrength = 5f;
    void Update() {
        useJetpack();
        
    }
    public void changeGravity() {
        // switches gravity whenever the player hits spacebar
        if (Input.GetKeyDown("space")) {
            if (controller.acceleration > 0) {
                controller.acceleration = -0.01f;
            } else if (controller.acceleration < 0) {
                controller.acceleration = 0.01f;
            }
        }
    }

    public void useJetpack() {
        if (Input.GetKey("space")) {
            controller.moveLikeAJetpack(0.5f);
        } else {
            controller.moveLikeAJetpack(-0.5f);
        }
    }
}
