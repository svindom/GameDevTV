using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPosition;

    public GameObject parallaxCamera;
    public float pallaxEffect;

    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float distance = (parallaxCamera.transform.position.x * pallaxEffect);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
    }
}
