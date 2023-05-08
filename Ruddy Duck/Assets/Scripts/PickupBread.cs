using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBread : MonoBehaviour
{
    BaseUnit playerStats;

    private void Awake() {
        playerStats = GameObject.Find("Player").GetComponent<BaseUnit>();
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log("Triggered");

        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            playerStats.IncreaseAllStats();
            Debug.Log("Player stats increased");
        }
    }
}
