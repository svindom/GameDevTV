using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public Color32 hasPackageColor = new Color32(1,1 ,1,1);
    public Color32 noPackageColor = new Color32(1,1 ,1,1);

    public float timerToDestroyObject = 0f;
    
    bool _hasPackage = false;
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("It works!");
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectPackage(collision);
        DeliverPackage(collision);

    }


    private void CollectPackage(Collider2D collision)
    {
        if (collision.tag == "Package" && !_hasPackage)
        {
            Debug.Log("The package picked up");
            _hasPackage = true;
            Destroy(collision.gameObject, timerToDestroyObject * Time.deltaTime);
            _spriteRenderer.color = hasPackageColor;
        }
    }

    private void DeliverPackage(Collider2D collision)
    {
        if (collision.tag == "Customer" && _hasPackage)
        {
            Debug.Log("The package has been delivered!");
            _hasPackage = false;
            _spriteRenderer.color = noPackageColor;
        }
    }
}
