using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    public Transform GroundCheck;
    public float CheckRadius = 0.1f;
    public LayerMask GroundMask;

    public Vector3 Velocity;
    public float Gravity = 9.81f;
    public float Mass = 1f;
    //public float AirResistance = -100f;
    public bool IsGrounded = true;

    Vector3 _prevVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, GroundMask) != null)
        {
            IsGrounded = true;
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
            Velocity.y += -Gravity * Time.deltaTime;
        }

        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = 0f;
        }

        transform.position += Velocity * Time.deltaTime;
    }

    public void AddForce(Vector3 force)
    {
        Velocity += force/Mass;

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
