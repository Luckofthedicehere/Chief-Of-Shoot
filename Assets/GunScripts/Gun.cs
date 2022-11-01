using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100F;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public float clipCount = 3;
    public int clipSize = 5;
    public int ammo = 5;

    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {

        if (ammo == 0 && clipCount > 1)
        {
            Reload();
        }
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire && ammo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();         
        }
    }

    void Shoot()
    {
        ammo -= 1;
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

    void Reload()
    {
        clipCount -= 1;
        ammo = clipSize;
    }
}
