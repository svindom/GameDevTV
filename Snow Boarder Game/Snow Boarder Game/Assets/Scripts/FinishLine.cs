using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTimeAfterFinish = 2f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioSource winSFX;
    private AudioClip _winClip;
    private readonly string _pathToWinSound = "Sounds/win";

    private void Awake()
    {
        finishEffect = GetComponentInChildren<ParticleSystem>();
        winSFX = GetComponent<AudioSource>();
        _winClip = Resources.Load<AudioClip>(_pathToWinSound); // here we load the sound
        winSFX.clip = _winClip; // here we assign the AudioClip to the AudioSource component
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finishEffect.Play();
            winSFX.Play();
            Invoke("ReloadScene", delayTimeAfterFinish);

        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
