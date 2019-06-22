using UnityEngine;
public class LightManager : MonoBehaviour {   
    void Update() {
        // moves the light source along the wave
        transform.position = new Vector3(Time.frameCount+150, 20, 0);
    }
}
