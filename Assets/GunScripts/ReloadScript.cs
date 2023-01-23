using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScript : MonoBehaviour
{

    public Slider slider;


    public void setMaxAmmo(int ammo)
    {
        slider.maxValue = ammo;
        slider.value = ammo;
    }

    public void SetAmmoCount(int ammo)
    {
        slider.value = ammo;
    }

    public IEnumerator reloadBar(float seconds)
    {
        float animationTime = 0f;
        while (animationTime < seconds)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / seconds;
            slider.value = Mathf.Lerp(0f, 1f, lerpValue);
            yield return null;
        }
    }

}
