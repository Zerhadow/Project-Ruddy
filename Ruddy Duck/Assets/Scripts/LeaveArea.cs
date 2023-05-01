using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveArea : MonoBehaviour
{
    public GameObject textBoxObj;
    KeyCode interactKey = KeyCode.E;
    bool leaveInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        textBoxObj.SetActive(false);
    }

    private void FixedUpdate() {
        if(Input.GetKey(interactKey) && leaveInteract) {
            Debug.Log("Interact key pressed");

            SceneManager.LoadScene("Arena");
        }
    }

    void OnTriggerEnter() {
        Debug.Log("Player entered the area");
        leaveInteract = true;

        textBoxObj.SetActive(true);
    }

    void OnTriggerExit() {
        Debug.Log("Player left the area");
        leaveInteract = false;

        textBoxObj.SetActive(false);
    }
}
