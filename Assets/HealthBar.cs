using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void Awake()
    {
        slider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
    }

    public IEnumerator setMaxHealth(float health, float delayTime)
    {
        slider.maxValue = health;
        slider.value = health;

        yield return new WaitForSeconds(delayTime);
    }

    public void setHealthCount(float health)
    {
        slider.value = health;
    }
}
