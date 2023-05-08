using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public BaseUnit unitStats;

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Player" || other.tag == "Ally" || other.tag == "Enemy") {
            // Debug.Log("Hit: " + other.name);
            BaseUnit otherStats = other.GetComponent<BaseUnit>();
            otherStats.GetComponent<BaseUnit>().TakeDamage(otherStats, unitStats);
        }

        if(this.tag == "Player" || this.tag == "Ally") {
            if(other.tag == "Enemy") {
                // Debug.Log("Hit: " + other.name);
                BaseUnit otherStats = other.GetComponent<BaseUnit>();
                otherStats.GetComponent<BaseUnit>().TakeDamage(otherStats, unitStats);
            }
        }

        if(this.tag == "Enemy") {
            if(other.tag == "Player" || other.tag == "Ally") {
                // Debug.Log("Hit: " + other.name);
                BaseUnit otherStats = other.GetComponent<BaseUnit>();
                otherStats.GetComponent<BaseUnit>().TakeDamage(otherStats, unitStats);
            }
        }
    }
}
