using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowButton : MonoBehaviour
{
    public void Throw()
    {
        int force;
        int angle;
        int.TryParse(ThrowManager.Instance.ForceText, out force);
        int.TryParse(ThrowManager.Instance.AngleText, out angle);

        ThrowManager.Instance.Throw(force, angle, true);
    }
}
