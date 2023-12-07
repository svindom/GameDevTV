using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _raynevan;
    SurfaceEffector2D _surfaceEffector;

    public float torqueAmount = 1f;
    public float boostSpeed = 20f;
    private float _speed = 14f;

    private void Awake()
    {
        _raynevan = GetComponent<Rigidbody2D>();
        _surfaceEffector = FindAnyObjectByType<SurfaceEffector2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        RotateRaynevan(torqueAmount);
        BoostSpeed();
    }



    public void RotateRaynevan(float torque)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _raynevan.AddTorque(torque);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _raynevan.AddTorque(-torque);
        }
    }

    private void BoostSpeed()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _surfaceEffector.speed = boostSpeed;
        }
        else
        {
            _surfaceEffector.speed = _speed;
        }
        
    }
}
