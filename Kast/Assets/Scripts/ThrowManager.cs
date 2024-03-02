using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowManager : MonoBehaviour
{
    public static ThrowManager Instance;

    public GameObject Throwable;
    public TMP_InputField InputFieldForce;
    public TMP_InputField InputFieldAngle;
    Physics _physics;

    public string ForceText;
    public string AngleText;

    Vector2 _pressedMousePos;
    Vector2 _prevThrowablePos;
    Vector2 _throwVector;

    float _throwAngle;

    bool _thrown;
    bool _disabled;
    bool _landed;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _physics = Throwable.GetComponent<Physics>();
        _prevThrowablePos = Throwable.transform.position;

        _thrown = false;
        _disabled = false;
        _landed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_thrown && !_disabled)
        {
            Setup();
        }
        if (_thrown && !_landed)
        {
            if (_physics.Velocity.y == 0)
            {
                Debug.Log(Throwable.transform.position.x - _prevThrowablePos.x);
                _landed = true;
            }
        }
    }

    private void Setup()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pressedMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            ForceText = InputFieldForce.text;
            AngleText = InputFieldAngle.text;
        }
        if (Input.GetMouseButton(0))
        {
            _throwVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - _pressedMousePos;

            for (int i = 0; i < 2; i++)
            {
                if (_throwVector[i] < 0)
                {
                    _throwVector[i] = 0;
                }
            }

            _throwAngle = Mathf.Atan2(_throwVector.y, _throwVector.x) * Mathf.Rad2Deg;

            InputFieldForce.text = _throwVector.magnitude.ToString() + "N";
            InputFieldAngle.text = _throwAngle.ToString() + " grader";
        }
        if (Input.GetMouseButtonUp(0))
        {
            Throw(_throwVector.magnitude, _throwAngle, false);
        }
    }

    public void Throw(float force, float angle, bool button)
    {
        if (button)
        {
            InputFieldForce.text = ForceText;
            InputFieldAngle.text = AngleText;
        }

        angle *= Mathf.Deg2Rad;
        Vector2 normalization = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        _physics.AddForce(normalization * force);
        _thrown = true;
    }

    public void DisabeSetup()
    {
        _disabled = true;
    }

    public void EnableSetup()
    {
        _disabled = false;
    }
}
