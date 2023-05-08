using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBread : MonoBehaviour
{
    BaseUnit playerStats;
    AudioSource eatingSound;

    private void Awake() {
        playerStats = GameObject.Find("Player").GetComponent<BaseUnit>();
        eatingSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log("Triggered");

        if (other.CompareTag("Player")) {
            eatingSound.PlayOneShot(eatingSound.clip);
            Destroy(gameObject);
            playerStats.IncreaseAllStats();
            Debug.Log("Player stats increased");
        }
    }
}
