using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    public HealthBar healthBar;



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
    }
}
