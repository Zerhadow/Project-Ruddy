using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigger(Collider other) {
        if(other.tag == "Enemy") {
            Debug.Log("Sword Hit: " + other.name);
            // other.GetComponent<EnemyHealth>().TakeDamage(10);
        }
    }
}
