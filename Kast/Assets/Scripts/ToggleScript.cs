using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public Global PhysicsStats;
    public Toggle _toggle;
    // Start is called before the first frame update
    void Start()
    {
        _toggle.isOn = PhysicsStats.CalculateAirResistance;
    }

    public void CalculateAirResistance()
    {
        PhysicsStats.CalculateAirResistance = _toggle.isOn;
    }
}
