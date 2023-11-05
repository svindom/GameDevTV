using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float spinSpeed = 0;

    GameObject _cart;
    Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, 0.1f);

        transform.Translate(0, 0.01f, 0);
    }
}
