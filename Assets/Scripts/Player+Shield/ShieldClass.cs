﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShieldType 
{
    carDoor,
    woodenPlank,    
    sewerCap,   
    ballisticShield,
    roadSign
}

[System.Serializable]
public class Shield 
{
    public ShieldType shieldType;
    public float weight;
    public float durability;
    public Sprite sprite;
}

public class ShieldClass : MonoBehaviour 
{
    // ESTO ES UN ESCUDO
}