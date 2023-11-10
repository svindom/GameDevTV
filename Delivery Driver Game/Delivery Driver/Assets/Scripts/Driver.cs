using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float spinSpeed = 0.1f;  // SerializeField allows us to stay private but be able to make adjustments via inspector
    public float MoveSpeed = 0.01f;

    GameObject cart;
    Rigidbody2D rg;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        DriveUsingGetAxis();
        SpeedUp();
        SpeedDown();
    }

    void DriveUsingGetAxis()
    {
        // GetAxis is a is a library with different movement abilities
        float horizontalMove = Input.GetAxis("Horizontal") * spinSpeed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -horizontalMove);    // to make an object rotates
        transform.Translate(0, verticalMove, 0);    // to make an object move straight forward
    }

    void DriveUsingInspectorOnly()
    {
        transform.Rotate(0, 0, spinSpeed);   
        transform.Translate(0, MoveSpeed, 0);  
    }

    void DriveUsingGetAxisHorizontalOnly()
    {
        float spinAmount = Input.GetAxis("Horizontal") * spinSpeed;
        transform.Rotate(0, 0, -spinAmount);
        transform.Translate(0, MoveSpeed, 0);
    }





    void SpeedUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveSpeed += 3;
        }
    }
    void SpeedDown()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MoveSpeed -= 3;

            if (MoveSpeed <= 0)
            {
                MoveSpeed = 0;
            }
        }
    }
}
