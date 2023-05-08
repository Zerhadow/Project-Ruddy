using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectable : MonoBehaviour
{
    public GameObject collectablePrefab;
    public float spawnTime = 1f;
    public Transform[] spawnPoints;
    public int maxBread = 3;
    public int maxCoins = 5;
    bool onCooldown1 = false;
    bool onCooldown2 = false;

    void Update() {
        //create a random function to see if bread will spawn
        if (Random.Range(0, 100) < 50 && !onCooldown1) {
            //spawn bread
            if (GameObject.FindGameObjectsWithTag("Bread").Length < maxBread) {
                Spawn();
            }
        }

        if (Random.Range(0, 100) < 10 && !onCooldown2) {
            //spawn bread
            if (GameObject.FindGameObjectsWithTag("Coin").Length < maxBread) {
                Spawn();
            }
        }
    }

    void Spawn() {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(collectablePrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
        // Debug.Log("SpawnPt Transform: " + spawnPoints[spawnPointIndex].position);
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(spawnTime);
    }
}
