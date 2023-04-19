using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTarget : MonoBehaviour
{
    public float health;
    public BossHealthBar healthBar;
    

    public void Start()
    {
        healthBar = GameObject.Find("BossHealthBar").GetComponent<BossHealthBar>();
        StartCoroutine(healthBar.setBossMaxHealth(health, 0.1f));
    }

    public void TakeDamage(float ammount)
    {
        health -= ammount;
        Debug.Log("Boss got hit");
        healthBar.setBossHealthCount(health);
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
