using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Global _physicsStats;
    [SerializeField] TMP_InputField _gravity;
    [SerializeField] TMP_InputField _airDensity;
    [SerializeField] TMP_InputField _mass;
    [SerializeField] Toggle _toggle;
    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _sliderText;
    // Start is called before the first frame update
    void Start()
    {
        _toggle.isOn = _physicsStats.CalculateAirResistance;
        _slider.value = _physicsStats.Elasticity;
        _gravity.text = _physicsStats.Gravity.ToString() + "m/s^2";
        _airDensity.text = _physicsStats.AirDensity.ToString() + "kg/m^3";
        _mass.text = _physicsStats.Mass.ToString() + "kg";

        AirResistance();
        SliderValue();
    }

    public void ChangeValue(TMP_InputField inputField)
    {
        float num;
        bool tryNum = float.TryParse(inputField.text, out num);

        if (tryNum && num > 0)
        {
            if (inputField == _gravity)
            {
                _physicsStats.Gravity = num;
            }
            else if (inputField == _airDensity)
            {
                _physicsStats.AirDensity = num;
            }
            else
            {
                _physicsStats.Mass = num;
            }
        }
        else
        {
            inputField.text = "";
        }
    }

    public void AirResistance()
    {
        _airDensity.gameObject.SetActive(_toggle.isOn);
    }

    public void CalculateAirResistance()
    {
        _physicsStats.CalculateAirResistance = _toggle.isOn;
    }

    public void SliderValue()
    {
        _sliderText.text = System.Math.Round(_slider.value, 1).ToString();
        _physicsStats.Elasticity = _slider.value;
    }
}
