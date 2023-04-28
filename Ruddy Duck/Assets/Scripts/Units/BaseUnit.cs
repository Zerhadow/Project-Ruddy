using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    string unitName = "";
    public double maxHP = 10;
    public double currentHP { get; private set; }
    public double Attack;
    public double Defense;
    public double Speed;
    public string skill;

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
}
