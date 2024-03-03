using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowButton : MonoBehaviour
{
    public void Throw()
    {
        float force;
        float angle;
        bool tryForce = float.TryParse(ThrowManager.Instance.InputFieldForce.text, out force);
        bool tryAngle = float.TryParse(ThrowManager.Instance.InputFieldAngle.text, out angle);

        if (tryForce && tryAngle)
        {
            ThrowManager.Instance.Throw(force, angle, true);
        }
        else
        {
            if (!tryForce)
            {
                ThrowManager.Instance.InputFieldForce.text = "";
            }
            if (!tryAngle)
            {
                ThrowManager.Instance.InputFieldAngle.text = "";
            }
        }
    }
}
