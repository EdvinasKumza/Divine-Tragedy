using System;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public string currentWeapon;

    public GameObject bulletPrefab;
    public GameObject slashPrefab;
    public Transform gunTransform;

    public float fireRate = 1.0f;  //Shots per second
    private float nextFireTime;

    public float bulletSpeed = 10f;

    public bool projectileUpgrade1 = false;
    public bool projectileUpgrade2 = false;
    public bool bulletSpeedUpgrade = false;
    public bool fireRateUpgrade = false;

    public void SetStartingWeapon(string weapon)
    {
        currentWeapon = weapon;
    }
    void Update()
    {
        // Aim the gun at the mouse cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Time.time > nextFireTime)
        {
            Shoot(currentWeapon);
            nextFireTime = Time.time + 1 / fireRate;
        }
    }

    public void Shoot(string weapon)
    {
        if(weapon == "bow")
        {
            if (bulletSpeedUpgrade) 
            {
                bulletSpeed = 20f;
            }
            else
            {
                bulletSpeed = 10f;
            }
            if (fireRateUpgrade)
            {
                fireRate = 2f;
            }
            else
            {
                fireRate = 1f;
            }

            // Instantiate a bullet and set its direction
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = gunTransform.right * bulletSpeed;
            
            if (projectileUpgrade1)
            {
                bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);

                float angleOffset = 5f;
                bullet.transform.Rotate(Vector3.forward, angleOffset);

                rb = bullet.GetComponent<Rigidbody2D>();

                Vector2 rotatedDirection = bullet.transform.right;
                Vector2 newVelocity = Quaternion.Euler(0, 0, angleOffset) * rotatedDirection;

                rb.velocity = newVelocity.normalized * bulletSpeed;
            }
            if (projectileUpgrade2)
            {
                bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);

                float angleOffset = -5f;
                bullet.transform.Rotate(Vector3.forward, angleOffset);

                rb = bullet.GetComponent<Rigidbody2D>();

                Vector2 rotatedDirection = bullet.transform.right;
                Vector2 newVelocity = Quaternion.Euler(0, 0, angleOffset) * rotatedDirection;

                rb.velocity = newVelocity.normalized * bulletSpeed;
            }

        }
        else if(weapon == "sword")
        {
            if (fireRateUpgrade)
            {
                fireRate = 1f;
            }
            else
            {
                fireRate = 0.5f;
            }
            bulletSpeed = 20f;

            GameObject bullet = Instantiate(slashPrefab, gunTransform.position, gunTransform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = gunTransform.right * bulletSpeed;

            if (projectileUpgrade1)
            {
                bullet = Instantiate(slashPrefab, gunTransform.position, gunTransform.rotation);

                float angleOffset = 20f;
                bullet.transform.Rotate(Vector3.forward, angleOffset);

                rb = bullet.GetComponent<Rigidbody2D>();

                Vector2 rotatedDirection = bullet.transform.right;
                Vector2 newVelocity = Quaternion.Euler(0, 0, angleOffset) * rotatedDirection;

                rb.velocity = newVelocity.normalized * bulletSpeed;
            }
            if (projectileUpgrade2)
            {
                bullet = Instantiate(slashPrefab, gunTransform.position, gunTransform.rotation);

                float angleOffset = -20f;
                bullet.transform.Rotate(Vector3.forward, angleOffset);

                rb = bullet.GetComponent<Rigidbody2D>();

                Vector2 rotatedDirection = bullet.transform.right;
                Vector2 newVelocity = Quaternion.Euler(0, 0, angleOffset) * rotatedDirection;

                rb.velocity = newVelocity.normalized * bulletSpeed;
            }
        }


    }
    public void Upgrade(string upgrade)
    {
        if(upgrade == "projectile1" && projectileUpgrade1 == true)
        {
            upgrade = "projectile2";
        }

        //if (currentWeapon == "bow")
        //{
            switch (upgrade)
            {
                case "projectile1":
                    projectileUpgrade1 = true;
                    break;
                case "projectile2":
                    projectileUpgrade2 = true;
                    break;
                case "bulletSpeed":
                    bulletSpeedUpgrade = true;
                    break;
                case "fireRate":
                    fireRateUpgrade = true;
                    break;
                default:
                    break;
            }
        //}
/*        else if (currentWeapon == "sword")
        {
            switch (upgrade)
            {
                case "projectile1":
                    projectileUpgrade1 = true;
                    break;
                case "projectile2":
                    projectileUpgrade2 = true;
                    break;
                case "fireRate":
                    fireRateUpgrade = true;
                    break;
                default:
                    break;
            }
        }*/

        
    }

    public void IncreaseFireRate()
    {
        fireRate *= 2;
    }
}
