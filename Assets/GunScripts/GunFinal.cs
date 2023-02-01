
using UnityEngine;
using UnityEngine.UI;

public class GunFinal : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots, impactForce;
    //mag size is num of bullets in mag, mag count is the number of mags a gun has
    public int magazineSize, bulletsPerTap, magazineCount;
    public bool allowButtonHold;
    [SerializeField] int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    //public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public GameObject muzzleFlash, bulletHoleGraphic;
    public ParticleSystem flash;
    public ReloadScript ammoBar;
    public Text bulletText;

    //public CameraShake camShake;
    // public float camShakeMagnitude, camShakeDuration;

    public void Start()
    {

        ammoBar.setMaxAmmo(magazineSize);
        ammoBar.SetAmmoCount(bulletsLeft);
        
    }

    public void OnEnable()
    {
        Invoke("functionNoParams", 0.1f);
        bulletText.text = bulletsLeft.ToString();
    }

    public void functionNoParams()
    {
        ammoBar.SetAmmoCount(bulletsLeft);
    }

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }
    private void MyInput()
    {
        if (allowButtonHold == false)
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading && magazineCount > 0)
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }


    }


    private void Shoot()
    {
        readyToShoot = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = attackPoint.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(attackPoint.transform.position, direction, out rayHit, range))
        {
            Debug.Log(rayHit.collider.name);
            EnemyTarget target = rayHit.transform.GetComponent<EnemyTarget>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (rayHit.rigidbody != null)
            {
                rayHit.rigidbody.AddForce(-rayHit.normal * impactForce);
            }




        }
        //StartCoroutine(camShake.Shake(camShakeDuration, camShakeMagnitude));

        GameObject impactEffect = Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal));
        flash.Play();
        //GameObject muzzleEffect = Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        Destroy(impactEffect, 2f);
          

        bulletsLeft--;
        bulletsShot--;
        ammoBar.SetAmmoCount(bulletsLeft);
        bulletText.text = bulletsLeft.ToString();

        Invoke("ResetShot", timeBetweenShooting);
        if (bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }


    private void Reload()
    {
        reloading = true;
        StartCoroutine(ammoBar.reloadBar(reloadTime));
        bulletText.text = "Reloading...";
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        ammoBar.SetAmmoCount(bulletsLeft);
        bulletText.text = bulletsLeft.ToString();
        magazineCount--;
        reloading = false;
    }
}
