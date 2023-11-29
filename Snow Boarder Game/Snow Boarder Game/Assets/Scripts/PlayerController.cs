using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _raynevan;
    public float torqueAmount = 1f;

    private void Awake()
    {
        _raynevan = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateRaynevan(torqueAmount);
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
}
