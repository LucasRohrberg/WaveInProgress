using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CubeManager : MonoBehaviour
{
    private float spawnTime;
    public int despawnTimer = 15;
    void Awake() {
        spawnTime = Time.time;
    }

    void FixedUpdate() {
        selfDestruct();
    }

    void selfDestruct() {
        if (Time.time - spawnTime > despawnTimer) {
            Destroy(gameObject);
        }
    }
}
