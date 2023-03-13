using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public float health;
    public HealthBar healthBar;
    public GameManager gmanage;


    public void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        StartCoroutine(healthBar.setMaxHealth(health, 0.1f));
    }

    public void TakeDamage(float ammount)
    {
        health -= ammount;
        Debug.Log("You got hit");
        healthBar.setHealthCount(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        gmanage.LoadLevel(6);
        
    }
}
