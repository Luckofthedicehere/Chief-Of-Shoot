using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTarget : MonoBehaviour
{
    public float health;
    public GameObject healthBar;
    public BossHealthBar healthBarScript;
    public Text bossName;

    public void Start()
    {
        
        if (this.gameObject.tag == "Boss")
        {
            bossName = GameObject.FindGameObjectWithTag("BossText").GetComponent<Text>();
            healthBar = GameObject.Find("BossHealthBar");
            healthBarScript = healthBar.GetComponent<BossHealthBar>();
            StartCoroutine(healthBarScript.setBossMaxHealth(health, 0.1f));
            bossName.text = this.gameObject.name;

        }
        
    }

    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if(healthBar != null)
        {
            healthBarScript.setBossHealthCount(health);
        }
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (healthBar != null)
        {
            healthBar.SetActive(false);
        }
        
       Destroy(gameObject);
    }
}
