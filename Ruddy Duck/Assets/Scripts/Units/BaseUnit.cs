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

    public int goldCost = 10; //cost to upgrade unit

    // public HUDHealth HPBar;

    void createUnit(string name, double hp, double attack, double defense, double speed, string skill) {
        unitName = name;
        maxHP = hp;
        currentHP = hp;
        Attack = attack;
        Defense = defense;
        Speed = speed;
        this.skill = skill;
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
}
