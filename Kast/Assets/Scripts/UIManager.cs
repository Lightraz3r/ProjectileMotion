using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Global PhysicsStats;
    public TMP_InputField Gravity;
    public TMP_InputField AirDensity;
    public TMP_InputField Mass;
    [SerializeField] Toggle _toggle;
    // Start is called before the first frame update
    void Start()
    {
        _toggle.isOn = PhysicsStats.CalculateAirResistance;
        AirResistance();

        Gravity.text = PhysicsStats.Gravity.ToString() + "m/s^2";
        AirDensity.text = PhysicsStats.AirDensity.ToString() + "kg/m^3";
        Mass.text = PhysicsStats.Mass.ToString() + "kg";
    }

    public void ChangeValue(TMP_InputField inputField)
    {
        float num;
        bool tryNum = float.TryParse(inputField.text, out num);

        if (tryNum && num > 0)
        {
            if (inputField == Gravity)
            {
                PhysicsStats.Gravity = num;
            }
            else if (inputField == AirDensity)
            {
                PhysicsStats.AirDensity = num;
            }
            else
            {
                PhysicsStats.Mass = num;
            }
        }
        else
        {
            inputField.text = "";
        }
    }

    public void AirResistance()
    {
        AirDensity.gameObject.SetActive(_toggle.isOn);
    }

    public void CalculateAirResistance()
    {
        PhysicsStats.CalculateAirResistance = _toggle.isOn;
    }
}
