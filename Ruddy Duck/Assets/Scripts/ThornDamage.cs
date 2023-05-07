using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" || other.tag == "Ally") {
            Debug.Log(other.name + " hit by thorns");
            other.GetComponent<BaseUnit>().TakeFlatDamage(5);
        }
    }
}
