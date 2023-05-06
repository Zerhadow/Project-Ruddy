using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int gold = 100;
    public int bread = 0;

    public AudioSource audioSource;
    public AudioClip quackSound;
    public AudioClip eatingSound;

    public GameObject PauseMenu;
    private bool paused = false;

    private bool isColliding = false;

    private BaseUnit playerUnit;
    public GameObject gameOverText;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerUnit = GetComponent<BaseUnit>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // play quack sound effect when Q button is pressed 
        if (Input.GetKeyDown(KeyCode.Q)) {
            audioSource.PlayOneShot(quackSound);
        }

        // play eating sound effect if player collided with object and presses E
        //  && Input.GetKeyDown(KeyCode.E)
        if (isColliding || Input.GetKeyDown(KeyCode.E)) {
            audioSource.PlayOneShot(eatingSound);
        }

        //if player left clicks, play attack animation
        if (Input.GetMouseButtonDown(0)) {
            StartCoroutine(AttackAnimation());
        }

        if(Input.GetKeyDown(KeyCode.P)) {
            // Debug.Log("P pressed");

            if(!paused) { //pause game
                paused = true;
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
            } else { //unpause game
                paused = false;
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
            }
        }

        if(playerUnit.currentHP <= 0) {
            // Debug.Log("Player is dead");
            Time.timeScale = 0;
            gameOverText.SetActive(true);
            StartCoroutine(Wait());

            //load title screen
            SceneManager.LoadScene("TitleScreen2");
        }
    }

    IEnumerator AttackAnimation() {
        //set attack animation to true
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1.45f);
        anim.SetBool("Attack", false);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Food") {
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Food") {
            isColliding = false;
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1);
    }
}
