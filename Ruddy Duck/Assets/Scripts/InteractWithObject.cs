using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public float interactDistance = 3f;
    public GameObject unitsPannelObj;
    public GameObject textBoxObj;
    KeyCode interactKey = KeyCode.E;
    bool npcInteract = false;
    private BaseUnit unitStats;

    void Start()
    {
        textBoxObj.SetActive(false);
        unitStats = GetComponent<BaseUnit>();
    }

    void FixedUpdate() {
        if(Input.GetKey(interactKey) && npcInteract) {
            Debug.Log("Interact key pressed");

            textBoxObj.SetActive(false);
            unitsPannelObj.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("In range of: " + other.name);
        // Debug.Log("Player in range for interaction");

        if(other.tag == "NPC") {
            npcInteract = true;

            textBoxObj.SetActive(true);
        }

        if(other.tag == "Enemy") {
            Debug.Log("Sword Hit: " + other.name);
            // other.GetComponent<EnemyHealth>().TakeDamage(10);
            BaseUnit enemyStats = other.GetComponent<BaseUnit>();
            other.GetComponent<BaseUnit>().TakeDamage(unitStats, enemyStats);
        }
    }

    

    private void OnTriggerExit(Collider other) {
        // Debug.Log("Player out of range for interaction");
        npcInteract = false;

        textBoxObj.SetActive(false);
    }
}
