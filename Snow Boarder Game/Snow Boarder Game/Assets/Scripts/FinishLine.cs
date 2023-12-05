using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTimeAfterFinish = 1.5f;
    [SerializeField] ParticleSystem finishEffect;

    private void Awake()
    {
        finishEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finishEffect.Play();
            Invoke("ReloadScene", delayTimeAfterFinish);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
