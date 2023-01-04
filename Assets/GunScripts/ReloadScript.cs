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

}
