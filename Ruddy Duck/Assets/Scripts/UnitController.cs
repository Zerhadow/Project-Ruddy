using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {
    //look for all game objects with tag "Player" or "Ally"
    List<GameObject> targets = new List<GameObject>();
    float distanceToNearestTarget = 100f;
    private GameObject currentTarget = null;

    private Animator anim;

    bool onCooldown = false;

    private void Awake() {
        anim = GetComponent<Animator>();
        
        if(this.tag == "Enemy") {
            //for each object that has the tag player, add it to the targets array
            for( int i = 0; i < 3; i++) {
                targets.Add(GameObject.FindGameObjectsWithTag("Ally")[i]);
                // Debug.Log("Enemies targets[" + i + "]: " + targets[i].name);
            }

            targets.Add(GameObject.Find("Player"));
        }
        
        if(this.tag == "Ally") {
            //for each object that has the tag enemy, add it to the targets array
            for( int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++) {
                targets.Add(GameObject.FindGameObjectsWithTag("Enemy")[i]);
                // Debug.Log("Allies targets[" + i + "]: " + targets[i].name);
            }

            // Debug.Log("Contents of target 1 for ally: " + targets[0].name);
        }
    }

    void Update() {
        //if there are no targets, return
        if(targets.Count == 0) {
            return;
        }

        FindNearestTarget();

        //if distance to current target is less than 2
        if(distanceToNearestTarget < 3.2f) {
            //play attack animation
            if(!onCooldown ) {
                StartCoroutine(AttackAnimation());
                StartCoroutine(AttackCooldown());
            }
        } else {
            //move towards target
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, 0.01f);
            anim.SetFloat("Velocity", 0.5f);
            // Debug.Log("Moving towards target");
        }

    }

    void FindNearestTarget() {
        foreach (GameObject target in targets) {
            // Debug.Log("Target: " + target.name);

            //get distance to current target
            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
            // Debug.Log("Distance to target: " + distanceToTarget);

            //if distance to current target is less than distance to nearest target
            if(distanceToTarget < distanceToNearestTarget) {
                //set nearest target to current target
                distanceToNearestTarget = distanceToTarget;
                currentTarget = target;
                // Debug.Log("Target: " + target.name);
            }
        }
    }

    IEnumerator AttackAnimation() {
        //set attack animation to true
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1.45f);
        anim.SetBool("Attack", false);
        onCooldown = true;
    }

    IEnumerator AttackCooldown() {
        yield return new WaitForSeconds(3f);
        onCooldown = false;
    }
}
