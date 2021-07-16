using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 4f;

    public int maxAmmo = 12;
    public int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    void Start ()
    {
        if (currentAmmo == -1)
            currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
          
        //if (Input.GetButton("triggerButton") && Time.time >= nextTimeToFire)
        //{
        //    nextTimeToFire = Time.time + 1f / fireRate;
        //    Shoot();
        //}
    }

    public void Trigger()
    {
        nextTimeToFire = Time.time + 1f / fireRate;
        Shoot();
    }

    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading Ammo");

        yield return new WaitForSeconds(reloadTime);
        
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    public void Shoot ()
    {
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null) 
            {
                enemy.TakeDamage(damage);
            }
        }
    }



}
