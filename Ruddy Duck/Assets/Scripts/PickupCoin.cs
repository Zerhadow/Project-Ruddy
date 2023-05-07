using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    public PlayerController PlayerController;

    void Update() {
        //rotate the coin
        transform.Rotate(0, 0, 80 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log("Triggered");

        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            PlayerController.gold += 100;
            Debug.Log("Player stats increased");
        }
    }
}
