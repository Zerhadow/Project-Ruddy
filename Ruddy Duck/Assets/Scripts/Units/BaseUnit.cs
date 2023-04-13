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

    // public HUDHealth HPBar;
}
