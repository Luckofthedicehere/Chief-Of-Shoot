using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScript : MonoBehaviour
{

    public Slider slider;


    public void Awake()
    {
        slider = GameObject.FindGameObjectWithTag("AmmoBar").GetComponent<Slider>();
    }



    public void setMaxAmmo(int ammo)
    {
        slider.maxValue = ammo;
        slider.value = ammo;

        //yield return new WaitForSeconds(delayTime);
    }

    public void SetAmmoCount(int ammo)
    {
        slider.value = ammo;
        //Debug.Log("Ammo: " + slider.value) ;

        //yield return new WaitForSeconds(delayTime);
    }

    public IEnumerator reloadBar(float seconds, float frame)
    {
        float animationTime = 0f;
        while (animationTime < seconds)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / seconds;
            slider.value = Mathf.Lerp(0f, frame, lerpValue);
            yield return null;
        }
    }

}
