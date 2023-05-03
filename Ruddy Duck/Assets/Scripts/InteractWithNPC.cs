using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithNPC : MonoBehaviour
{
    public float interactDistance = 3f;
    public GameObject unitsPannelObj;
    public GameObject textBoxObj;
    KeyCode interactKey = KeyCode.E;
    bool npcInteract = false;

    void Start()
    {
        textBoxObj.SetActive(false);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(interactKey) && npcInteract)
        {
            Debug.Log("Interact key pressed");

            textBoxObj.SetActive(false);
            unitsPannelObj.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In range of: " + other.name);
        // Debug.Log("Player in range for interaction");

        if (other.tag == "NPC")
        {
            npcInteract = true;

            textBoxObj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player out of range for interaction");
        npcInteract = false;

        textBoxObj.SetActive(false);
    }
}
