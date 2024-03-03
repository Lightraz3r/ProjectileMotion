using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Global")]
public class Global : ScriptableObject
{
    public float Gravity;
    public float AirDensity;
    public float Mass;
    public bool CalculateAirResistance;
}
