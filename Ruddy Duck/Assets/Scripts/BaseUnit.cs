using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string unitName = "";
    public double maxHP = 10;
    public double currentHP { get; private set; }
    public double Attack;
    public double Defense;
    public double Speed;
    public string skill;

    private bool blocked = false; 
    private bool doubleAttack = false; 

    public int goldCost = 10; //cost to upgrade unit

    // public HUDHealth HPBar;

    void Awake() {
        currentHP = maxHP;
    }

    void FixedUpdate() {
        if(currentHP <= 0) {
            Debug.Log(unitName + " has died."); 
            Destroy(gameObject);
        }
    }

    // void createUnit(string name, double hp, double attack, double defense, double speed, string skill) {
    //     unitName = name;
    //     maxHP = hp;
    //     currentHP = hp;
    //     Attack = attack;
    //     Defense = defense;
    //     Speed = speed;
    //     this.skill = skill;
    // }

    public float GetCurrHP() {
        return (float)currentHP;
    }

    public void IncreaseHP() {
        maxHP += 10;
        currentHP = maxHP;
        goldCost += 5;
    }

    public void IncreaseAttack() {
        Attack += 1;
        goldCost += 5;
    }

    public void IncreaseDefense() {
        Defense += 1;
        goldCost += 5;
    }

    public void IncreaseSpeed() {
        Speed += 1;
        goldCost += 5;
    }

    public void TakeDamage(BaseUnit attacker, BaseUnit defender) { 
        Debug.Log(attacker.unitName + " attacks " + defender.unitName); 

        //Defense formula: compare def v. Atk. If def higher, remainder is percent chance of block 
        if (defender.Defense > attacker.Attack) { 
            double remainder = defender.Defense - attacker.Attack; 
            double blockChance = (remainder / defender.Defense) * 100; 

            //random value between 0 and 100 
            double random = Random.Range(0, 100); 

            if (random < blockChance) { 
                blocked = true; 
                Debug.Log("Attack Blocked"); 
            } 
        }  
        // Speed formula: compare spd v spd. If faster, remainder is chance to double 
        if (defender.Speed > attacker.Speed) { 
            double remainder = defender.Speed - attacker.Speed; 
            double doubleChance = (remainder / defender.Speed) * 100; 

            //random value between 0 and 100 
            double random = Random.Range(0, 100); 

            if (random < doubleChance) { 
                doubleAttack = true; 
                Debug.Log("Double Attack"); 
            } 
        } 

        if(!blocked) { 
            if(doubleAttack) { 
                currentHP -= (attacker.Attack * 2); 
                Debug.Log("defender takes " + (attacker.Attack * 2) + " damage"); 
            } else { 
                currentHP -= attacker.Attack; 
                Debug.Log("defender takes " + attacker.Attack + " damage"); 
            } 
        } 

        blocked = false; 
        doubleAttack = false;        
    }

    public void TakeFlatDamage(double damage) {
        currentHP -= damage;
        // Debug.Log(unitName + " takes " + damage + " damage");
    }
}
