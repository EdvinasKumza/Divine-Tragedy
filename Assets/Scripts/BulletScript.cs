using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10.0f;
    public GameObject hitEffect;
    public int pierce = 1;

    public float maxDistance = 10f;
    private float distanceTraveled = 0f;
     
    void Update()
    {
        distanceTraveled += 20f * Time.deltaTime;
        if(distanceTraveled > maxDistance)
        {
            Destroy(gameObject);
        }

    }

    /*void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < -1000 || screenPos.x > Screen.width+1000 || screenPos.y < -1000 || screenPos.y > Screen.height+1000)
        {
            Destroy(gameObject);
        }
    }
*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                --pierce;
            }

            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }

            if (pierce <= 0)
            {
                Destroy(gameObject);
            }

        }
        else if(other.CompareTag("Player")) 
        { 
        }
        else
        {
            // Destroy the bullet if it hits any other object
            Destroy(gameObject);
        }
    }
}
