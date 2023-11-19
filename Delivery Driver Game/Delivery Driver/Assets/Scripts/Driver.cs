using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float _spinSpeed = 0.1f;  // SerializeField allows us to stay private but be able to make adjustments via inspector
    public float moveSpeed = 3.0f;
    public float slowSpeed = 0.05f;
    public float boostSpeedUp = 5.0f;

    private bool _IsOnBoosterSpeedUp = false;


    GameObject _cart;
    Rigidbody2D _rigitbody;

    private void Awake()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D collisionRoad)
    {
        if (collisionRoad.tag == "SpeedUp" && !_IsOnBoosterSpeedUp)
        {
            moveSpeed += boostSpeedUp;
            Debug.Log("On speed up");
            _IsOnBoosterSpeedUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SpeedUp" && _IsOnBoosterSpeedUp)
        {
            moveSpeed -= boostSpeedUp;
            Debug.Log("Not on a speed up road");
            _IsOnBoosterSpeedUp = false;
        }
    }


    void DriveUsingGetAxis()
    {
        // GetAxis is a is a library with different movement abilities
        float horizontalMove = Input.GetAxis("Horizontal") * _spinSpeed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -horizontalMove);    // to make an object rotates
        transform.Translate(0, verticalMove, 0);    // to make an object move straight forward
    }

    void DriveUsingInspectorOnly()
    {
        transform.Rotate(0, 0, _spinSpeed);
        transform.Translate(0, moveSpeed, 0);
    }

    void DriveUsingGetAxisHorizontalOnly()
    {
        float spinAmount = Input.GetAxis("Horizontal") * _spinSpeed;
        transform.Rotate(0, 0, -spinAmount);
        transform.Translate(0, moveSpeed, 0);
    }


    void SpeedUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            moveSpeed += 1.5f;
        }
    }
    void SpeedDown()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            moveSpeed -= 1.5f;

            if (moveSpeed <= 0)
            {
                moveSpeed = 0;
            }
        }
    }
}


