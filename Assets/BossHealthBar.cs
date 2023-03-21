using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider bossSlider;

    public void Awake()
    {
        bossSlider = GameObject.FindGameObjectWithTag("BossHealthBar").GetComponent<Slider>();
    }

    public IEnumerator setBossMaxHealth(float health, float delayTime)
    {
        bossSlider.maxValue = health;
        bossSlider.value = health;

        yield return new WaitForSeconds(delayTime);
    }

    public void setBossHealthCount(float health)
    {
        bossSlider.value = health;
    }
}
