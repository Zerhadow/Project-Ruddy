using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithNPC : MonoBehaviour
{
    public float interactDistance = 2f;
    public GameObject unitsPannelObj;
    KeyCode interactKey = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Player in range for interaction");

        if(Input.GetKeyDown(interactKey)) {
            Debug.Log("Interacted with NPC");
            unitsPannelObj.SetActive(true);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }
}
