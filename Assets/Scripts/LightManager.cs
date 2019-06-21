using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LightManager : MonoBehaviour {   
    void Update() {
        transform.position = new Vector3(Time.frameCount+50, 30, 0);
    }
}
