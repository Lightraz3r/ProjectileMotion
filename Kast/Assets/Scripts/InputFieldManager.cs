using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldManager : MonoBehaviour
{
    public Global PhysicsStats;
    public TMP_InputField Gravity;
    public TMP_InputField AirDensity;
    public TMP_InputField Mass;
    // Start is called before the first frame update
    void Start()
    {
        Gravity.text = PhysicsStats.Gravity.ToString() + "m/s^2";
        AirDensity.text = PhysicsStats.AirDensity.ToString() + "kg/m^3";
        Mass.text = PhysicsStats.Mass.ToString() + "kg";
    }

    public void ChangeValue(TMP_InputField inputField)
    {
        float num;
        bool tryNum = float.TryParse(inputField.text, out num);

        if (tryNum)
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
}
