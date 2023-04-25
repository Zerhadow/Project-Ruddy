using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithNPC : MonoBehaviour
{
    public float interactDistance = 2f;
    public GameObject unitsPannelObj;
    KeyCode interactKey = KeyCode.E;
    bool interacted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(Input.GetKey(interactKey)) {
            Debug.Log("Interact key pressed");

            if(interacted) {
                Debug.Log("Interacted with NPC");
                unitsPannelObj.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Player in range for interaction");
        interacted = true;
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Player out of range for interaction");
        interacted = false;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }
}
