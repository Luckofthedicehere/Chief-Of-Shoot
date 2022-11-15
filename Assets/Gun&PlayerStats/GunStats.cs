using UnityEngine;

[CreateAssetMenu (fileName = "GunScriptableObject", menuName = "ScriptableObjects/Gun1")]

public class GunStats : ScriptableObject
{
    public float damage = 10f;
    public float range = 100F;
    public float impactForce = 30f;
    public float fireRate = 15f;
}
