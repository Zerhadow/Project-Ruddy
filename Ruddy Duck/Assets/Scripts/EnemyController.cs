using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    //look for all game objects with tag "Player" or "Ally"
    public GameObject[] targets;

    private Animator anim;

    private void Awake() {
        //find all game objects with tag "Player" or "Ally"
        targets = GameObject.FindGameObjectsWithTag("Player");
        targets = GameObject.FindGameObjectsWithTag("Ally");

        //get animator component
        anim = GetComponent<Animator>();
    }

    void Update() {
        //if there are no targets, return
        if(targets.Length == 0) {
            return;
        }

        //loop through all targets

        for(int i = 0; i < 4; i++) {
            //get distance between enemy and target
            float distance = Vector3.Distance(transform.position, targets[i].transform.position);

            //if distance is less than 5, attack target
            if(distance < 5f) {
                //attack target
                StartCoroutine(AttackAnimation());
            } else {
                //move towards target
                transform.position = Vector3.MoveTowards(transform.position, targets[i].transform.position, 0.1f);
            }
        }
    }

    IEnumerator AttackAnimation() {
        //set attack animation to true
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1.45f);
        anim.SetBool("Attack", false);
    }
}
