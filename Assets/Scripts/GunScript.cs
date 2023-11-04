using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunTransform;

    public float fireRate = 1.0f;  //Shots per second
    private float nextFireTime;

    public float bulletSpeed = 10f;

    void Update()
    {
        // Aim the gun at the mouse cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1 / fireRate;
        }
    }

    void Shoot()
    {
        // Instantiate a bullet and set its direction
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = gunTransform.right * bulletSpeed;
    }
}
