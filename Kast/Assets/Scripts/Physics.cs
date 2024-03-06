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
    public bool IsGrounded { get; private set; }

    Vector2 _startPos;

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

        if (IsGrounded && Velocity.y < 0)
        {
            //Velocity.x *= Velocity.normalized.x;
            //Velocity.y = Velocity.y * Velocity.normalized.y - Stats.Gravity * Time.deltaTime;
            Velocity.x *= Stats.Elasticity;
            Velocity.y *= -Stats.Elasticity;
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

            Velocity += dragNorm * dragForce;
        }

        transform.position += (Vector3)Velocity * Time.deltaTime;
    }

    public void AddVelocity(Vector2 velocity)
    {
        Velocity += velocity;
    }
}
