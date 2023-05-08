using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController : MonoBehaviour
{
    GameObject currentTarget;
    private Animator anim;

    bool onCooldown = false;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") {
            currentTarget = other.gameObject;

            Vector3 direction = currentTarget.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
            
            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCooldown());
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
