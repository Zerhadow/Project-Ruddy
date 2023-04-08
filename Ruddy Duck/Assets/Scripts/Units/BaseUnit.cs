using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public double maxHP = 10;
    public double currentHP { get; private set; }
    public double Attack;
    public double Defense;
    public double Speed;

    public public HUDHealth HPBar;
}
