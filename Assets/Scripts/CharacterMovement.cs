using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    public float currentHeight = 40f; 
    public bool breaksEnabled = false;
    
    public float acceleration = 0.01f;
    public float heightBeforeBreak = 0f;
    public bool jetpackEnabled = false;
    private float characterHeight;

    void Awake() {
        characterHeight = transform.position.y;
    }

    public void moveWithGravity(float _maxSpeed, float _breakStrength) {
        // accelerates over time and enables breaks (like... those of a car) when switching gravity, allowing to turn quicker
        currentHeight -= acceleration;
        if (3 * acceleration < _maxSpeed && 3 * acceleration > _maxSpeed * - 1) acceleration += acceleration;
        transform.position = new Vector3(Time.frameCount, currentHeight, -20);
    }

    public void moveLikeAJetpack(float _gain) {
        characterHeight = characterHeight + _gain;
        transform.position = new Vector3(Time.frameCount, characterHeight, -20f);
    }
}