using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    public int health = 3;
    public UIManager uiManager;
    public float delayTimeAfterLose = 1.5f;
    private bool isDead = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ReceiveDamage();
            if (!isDead) 
            {
                Invoke("Lose", delayTimeAfterLose);
            }       
        }
    }

    private void ReceiveDamage()
    {
        health--;
        uiManager.SetHealth(health);
    }

    private void Lose()
    {
        if (health <= 0)
        {
            if (!isDead)
            {
                Debug.Log("Ouch, hit my head!");
                SceneManager.LoadScene(0);
                isDead = true;
            }
        }
    }
}
