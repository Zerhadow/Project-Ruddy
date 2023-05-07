using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBread : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;
    BaseUnit playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerStats = player.GetComponent<BaseUnit>();
    }

    void OntriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            
            playerController.bread += 1;
        }
    }
}
