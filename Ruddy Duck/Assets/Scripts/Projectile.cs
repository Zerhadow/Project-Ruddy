using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rigidbody;
    [Min(0f)]
    public float despawnDistance;
    GameObject enemy;
    public GameObject shooter;
    // Units shooterStat;
    Transform player;

    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        // shooterStat = shooter.GetComponent<Units>();


    }

    void Update() {
        if(transform.position.magnitude > despawnDistance)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector3 direction, float force) {
        rigidbody.AddForce(direction * force);
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log("Bullet hit " + other.name);
        if(this.tag == "PlayerBullet") {
            if(other.tag == "Enemy") {
                // Units enemyStat = other.gameObject.GetComponent<Units>();
                // enemyStat.TakeDmg(shooterStat.dmg);
                // Debug.Log("Enemy HP: " + enemyStat.currHP);        
                //Instantiate(particles,transform.position,Quaternion.identity);
                //AudioManager.PlaySound("BulletCollide");
                Destroy(gameObject);
            } else if(other.tag == "Player") {
                Debug.Log("collide w player");
            }
        } else if(this.tag == "EnemyBullet"){
            if(other.tag == "Player") {
                // Units playerStat = other.gameObject.GetComponent<Units>();
                // if(!playerStat.invincible){
                //     //Instantiate(particles,transform.position,Quaternion.identity);
                
                //     player.GetComponent<PlayerController>().TakeDmg(15);
                //     Vector2 target = new Vector2(player.position.x, player.position.y); //Keep speed at zero to not have boss move
                //     Vector2 newPos = Vector2.MoveTowards(rigidbody2d.position, target, 2 * Time.fixedDeltaTime);
                //     rigidbody2d.MovePosition(newPos);
                //     Debug.Log("Player HP: " + playerStat.currHP);        
                //     Destroy(gameObject);
                // }
            }
        }
    }

}