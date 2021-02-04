using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Machinegun_Scripted : MonoBehaviour
{
    // https://www.youtube.com/watch?v=wZ2UUOC17AY&ab_channel=Dave%2FGameDevelopment Inspirace (není to stejné, použili jsme jiný postup)

    [Header("Mesh:")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject muzzleFlash;

    [Header("Bullet stats")]
    [SerializeField] float shootForce;
    [SerializeField] float upwardForce;

    [Header("Gun stats")]
    [SerializeField] float timeBetweenShoting;
    [SerializeField] float spread;
    [SerializeField] float range;
    [SerializeField] float reloadTime;
    [SerializeField] float timeBetweenShots;

    [SerializeField] int bulletsPerClick;
    [SerializeField] int magazineSize;
    [SerializeField] int magazinesLeft; // Ještě jsem nedodělal

    [SerializeField] bool allowHoldButton;

    [Header("Gun objects")]
    [SerializeField] Transform bulletSpawn;

    [Header("UI")]
    public TextMeshProUGUI ammoDisplay; 

    [SerializeField] int bulletsLeft;
    int bulletsShot;

    bool shooting = false;
    bool readyToShoot;
    bool reloading = false;

    bool allowInvoke = true;

    // Start is called before the first frame update
    void Start()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayersInput();

        AmmoDisplay();
    }

    private void AmmoDisplay()
    {
        if (ammoDisplay != null)
            ammoDisplay.SetText(bulletsLeft / bulletsPerClick + "/" + magazineSize / bulletsPerClick);
    }

    private void PlayersInput()
    {
        // Check allowHoldButton (bool)
        if (allowHoldButton == true) shooting = Input.GetButton("Fire1");
        else shooting = Input.GetButtonDown("Fire1");

        // Nabít skrze input --- Možná přidám, že se nedá zároveň létat a nabíjet
        if (Input.GetButtonDown("Reload") && bulletsLeft < magazineSize && !reloading)
            Reload();
        // Nabít pokud střílí bez munice
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
            Reload();


        // Shooting
            if (readyToShoot && shooting && (reloading == false) && (bulletsLeft > 0))
        {
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        Vector3 bulletSpawnPos = bulletSpawn.transform.position; // Pozice dítěte
        Ray ray = new Ray(bulletSpawnPos, Vector3.forward * range); // raycast z pozice dítěte, dopřed, na vzdálenost
        RaycastHit hit;
        Vector3 targetPoint;

        Debug.DrawRay(bulletSpawnPos, Vector3.forward * range, Color.cyan);

        if (Physics.Raycast(ray, out hit, range)) // raycast z pozice dítěte, dopřed, na vzdálenost
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(range);
        }

       // Debug.Log("target X " + targetPoint.x + " y " + targetPoint.y + " z " + targetPoint.z);

        Vector3 directionWithoutSpread = targetPoint - bulletSpawnPos;

        //Spread
        float x = UnityEngine.Random.Range(-spread, spread);
        float y = UnityEngine.Random.Range(-spread, spread);
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instance Bullet
        GameObject currentBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        currentBullet.transform.right = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        //Pouze pro "skákající" střelu currentBullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.transform.up * shootForce, ForceMode.Impulse);

        if (muzzleFlash != null)
            Instantiate(muzzleFlash, bulletSpawn.position, Quaternion.identity);

        bulletsLeft = bulletsLeft - 1;
        bulletsShot = bulletsShot + 1;

        if (allowInvoke == true)
        {
            Invoke("ResetShot", timeBetweenShoting);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerClick && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot() // POOOOOOOZOOOOOOR MOTHAFUKA STRINGOVÁ REFERENCE
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
