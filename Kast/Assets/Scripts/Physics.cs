using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Physics : MonoBehaviour
{
    public Transform GroundCheck;
    public float CheckRadius = 0.1f;
    public LayerMask GroundMask;

    [HideInInspector] public Vector2 Velocity;
    public Global Stats;
    //public float Gravity = 9.81f;
    //public float AirDensity = 1f;
    //public float Mass = 1f;
    //public float AirResistance = -100f;
    public bool IsGrounded { get; private set; }

    Vector2 _prevVelocity;
    Vector2 _startPos;
    //bool _calculateAirResistance;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= _startPos.y)
        {
            IsGrounded = true;
            transform.position = new Vector3(transform.position.x, _startPos.y, transform.position.z);
        }
        else
        {
            IsGrounded = false;
        }

        //if (Velocity.x != 0 && !ChangedCharge(Velocity.x, _prevVelocity.x))
        //{
        //    int mod = Charge(Velocity.x);
        //    Velocity.x += AirResistance * mod * Time.deltaTime;
        //}
        //else
        //{
        //    Velocity.x = 0f;
        //}

        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = 0;
        }
        else
        {
            Velocity.y += -Stats.Gravity * Time.deltaTime;
        }

        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = 0f;
        }

        if (!IsGrounded && Stats.CalculateAirResistance)
        {
            Vector2 dragNorm = -Velocity.normalized;

            float dragForce = 0.45f * Stats.AirDensity * Mathf.PI * Mathf.Pow(transform.localScale.x, 2) * Velocity.magnitude * 0.5f * Time.deltaTime;

            Debug.Log(dragForce);
            Debug.Log(dragNorm);
            Debug.Log(Velocity);

            Velocity += dragNorm * dragForce;
        }

        transform.position += (Vector3)Velocity * Time.deltaTime;
    }

    public void AddForce(Vector2 force)
    {
        Velocity += force/Stats.Mass;

        _prevVelocity.x = Velocity.x;
    }

    private bool ChangedCharge(float current, float prev)
    { // Checks if a number has changed its charge
        if (current > 0f && prev < 0f)
        {
            return true;
        }
        else if (current > 0f && prev > 0f)
        {
            return false;
        }
        else if (current < 0f && prev > 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int Charge(float number)
    { // Checks the charge of the number
        if (number >= 0f)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
