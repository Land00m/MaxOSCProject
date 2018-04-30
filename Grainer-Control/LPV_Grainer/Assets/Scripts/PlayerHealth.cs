//using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Utility;
using UnityStandardAssets.CrossPlatformInput;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;




public class PlayerHealth : MonoBehaviour

{
    public bool
    enemyInRange, playerDamaged;
    public bool playerDead;
    public float
    timeBetweenDamage, timer;
    public int
    maxHealth = 100, currentHealth, 
    damageAmount = 5;
    public float nextActionTime = 0.0f;
    public float nextActionPeriod = 1.0f;

    public AudioSource playerAudio;
    public AudioClip playerHurt;

    public Slider healthSlider;
    SimpleCharacterControl playerController;
    FirstPersonController playerFPSController;

    GameObject deathTextObject;
    Text deathText;

    Image deathButtonImage;

    Text deathButtonText;


	void Start()
    {
        timeBetweenDamage = 1.0f;
        playerDead = false;
        maxHealth = 100;
        currentHealth = maxHealth;
        damageAmount = 5;
        playerAudio = gameObject.GetComponent<AudioSource>();
        playerController = gameObject.GetComponent<SimpleCharacterControl>();
        playerFPSController = gameObject.GetComponent<FirstPersonController>();

        deathTextObject = GameObject.Find("DeathText");
        //deathText = deathTextObject.GetComponent<Text>();

		playerController.enabled = true;
        //deathText.enabled = false;

    }

    void Update()
    {
        timer += Time.deltaTime;
        healthSlider.value = currentHealth;

        if (timer >= timeBetweenDamage && enemyInRange == true && currentHealth > 0)
        {
            TakeDamage();

        }

        //Limits the current health to not go over 100;
        if (currentHealth > 100)

        {
            currentHealth = 100;
        }

        //Reduces health every x seconds;
        if (Time.time > nextActionTime && currentHealth > 0)
        {
            nextActionTime += nextActionPeriod;
            currentHealth += 1;
        }

        if (currentHealth <= 0)
        {
            Death();
        }

        playerDamaged = false;

        if (playerDead == true)
        {
            
        }
    }

    void TakeDamage()
    {
        timer = 0.0f;
        playerDamaged = true;
        currentHealth -= damageAmount;
        playerAudio.PlayOneShot(playerHurt);


    }

    void Death()
    {
        playerDead = true;
        playerController.enabled = false;
        playerFPSController.enabled = false;
        deathText.enabled = true;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Restart();
        }

        //add whatever menu or gui needs to appear;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            enemyInRange = true;

        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Enemy")
        {
            enemyInRange = false;

        }
    }

    public void Restart()
    {
        playerController.enabled = true;
        playerFPSController.enabled = true;
        SceneManager.LoadScene(0);
    }
}