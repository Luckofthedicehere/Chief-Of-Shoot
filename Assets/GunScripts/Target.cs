using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
    public HealthBar healthBar;



    public void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        healthBar.setMaxHealth(health);
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
