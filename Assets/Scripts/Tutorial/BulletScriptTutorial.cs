using UnityEngine;

public class BulletTutorial : MonoBehaviour
{
    public float damage = 10.0f;
    public GameObject hitEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyTutorial enemy = other.GetComponent<EnemyTutorial>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
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
