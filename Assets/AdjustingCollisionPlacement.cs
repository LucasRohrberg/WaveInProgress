using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustingCollisionPlacement : MonoBehaviour {
    void Update() {
        transform.position = new Vector3(FindObjectOfType<CharacterMovement>().transform.position.x, FindObjectOfType<CharacterMovement>().transform.position.y, 0);
    }
}
