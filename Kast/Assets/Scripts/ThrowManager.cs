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
    LineRenderer _line;

    Vector2 _pressedMousePos;
    Vector2 _prevThrowablePos;
    Vector2 _throwVector;

    float _throwAngle;

    bool _thrown;
    bool _disabled;
    bool _landed;
    bool _pressed;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _physics = Throwable.GetComponent<Physics>();
        _line = GetComponent<LineRenderer>();

        _prevThrowablePos = Throwable.transform.position;

        _thrown = false;
        _disabled = false;
        _landed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(HoveringOver.Touching);
        if (!HoveringOver.Touching)
        {
            if (!_thrown && !_disabled)
            {
                Setup();
            }
        }
        if (_thrown && !_landed)
        {
            if (_physics.Velocity.y == 0)
            {
                ResultManager.Instance.Results();
                _landed = true;
            }
        }
    }

    private void Setup()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pressedMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _throwVector = mousePos - _pressedMousePos;

            _line.SetPosition(0, _pressedMousePos);
            _line.SetPosition(1, mousePos);

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
        if (Input.GetMouseButtonUp(0) && _pressed)
        {
            for (int i = 0; i < 2; i++)
            {
                _line.SetPosition(i, Vector3.zero);
            }
            Throw(_throwVector.magnitude, _throwAngle, false);
        }
        _pressed = Input.GetMouseButton(0);
    }

    public void Throw(float force, float angle, bool button)
    {
        angle *= Mathf.Deg2Rad;
        Vector2 normalization = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        _physics.AddForce(normalization * force);
        ResultManager.Instance.StartVelocity = force;
        _thrown = true;
    }
}
