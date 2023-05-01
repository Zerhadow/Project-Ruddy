using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int gold = 100;

    public AudioSource audioSource;
    public AudioClip quackSound;
    public AudioClip eatingSound;

    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // play quack sound effect when Q button is pressed 
        if (Input.GetKeyDown(KeyCode.Q)) {
            audioSource.PlayOneShot(quackSound);
        }

        // play eating sound effect if player collided with object and presses E
        //  && Input.GetKeyDown(KeyCode.E)
        if (isColliding) {
            audioSource.PlayOneShot(eatingSound);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food") {
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Food") {
            isColliding = false;
        }
    }
}
