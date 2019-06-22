using UnityEngine;
public class CubeManager : MonoBehaviour {
    private float spawnTime;
    public int despawnTimer = 4;
    void Awake() {
        spawnTime = Time.time;
        Invoke("selfDestruct", despawnTimer);
    }

    void Update() {
        // Makes the cubes fall down after a delay
        
        // if (Time.time - spawnTime > 3) {
        //     if (transform.position.y > 50) {
        //         transform.position += new Vector3(0, -0.5f, 0);
        //     }
        // }
    }
    void selfDestruct() {
        // rather self explainatory :D
        Destroy(gameObject);
    }
}
