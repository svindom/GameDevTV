using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    public UIManager uiManager;
    public int health = 3;
    public float delayTimeAfterLose = 3f;
    private bool _isDead = false;

    //Crash fields
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioSource crashSFX;
    private AudioClip _crashSFXClip;
    private readonly string _pathToCrashSound = "Sounds/hit";

    //Lose fields
    [SerializeField] AudioSource loseSFX; // Reference to the lose AudioSource
    private AudioClip _loseSFXClip;
    private readonly string _pathToLoseSound = "Sounds/lose";




    private void Awake()
    {
        // Crash
        hitEffect = GetComponentInChildren<ParticleSystem>();
        crashSFX = GetComponent<AudioSource>();
        _crashSFXClip = Resources.Load<AudioClip>(_pathToCrashSound);
        crashSFX.clip = _crashSFXClip;

        _loseSFXClip = Resources.Load<AudioClip>(_pathToLoseSound);
        loseSFX = GetComponents<AudioSource>()[1]; // Get the second AudioSource
        loseSFX.clip = _loseSFXClip; // Assign the AudioClip

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ReceiveDamage();
            if (!_isDead) 
            {
                StartCoroutine(HandleLoseSequence());
            }       
        }
    }

    private void ReceiveDamage()
    {
        health--;
        uiManager.SetHealth(health);
        if (health >= 0) 
        {
            crashSFX.PlayOneShot(_crashSFXClip);
            hitEffect.Play();
        }

    }

    private IEnumerator HandleLoseSequence()
    {
        if (health <= 0)
        {
                health = 0;
                loseSFX.Play(); // Play the lose sound
                Debug.Log("Ouch, I've hit my head!");
                _isDead = true;

            yield return new WaitForSeconds(Mathf.Max(loseSFX.clip.length, delayTimeAfterLose));

            SceneManager.LoadScene(0);      
        }
    }
}
