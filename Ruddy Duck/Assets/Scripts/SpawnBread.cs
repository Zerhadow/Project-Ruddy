using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBread : MonoBehaviour
{
    public GameObject breadPrefab;
    public float spawnTime = 1f;
    public Transform[] spawnPoints;
    public int maxBread = 3;
    bool onCooldown = false;

    void Update() {
        //create a random function to see if bread will spawn
        if (Random.Range(0, 100) < 10 && !onCooldown) {
            //spawn bread
            if (GameObject.FindGameObjectsWithTag("Bread").Length < maxBread) {
                Spawn();
            }
        }
    }

    void Spawn() {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(breadPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
        Debug.Log("SpawnPt Transform: " + spawnPoints[spawnPointIndex].position);
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(spawnTime);
    }
}
