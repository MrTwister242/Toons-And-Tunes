using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(100f, 500f)] float maxHealth = 250f;

    // State
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {

        maxHealth -= damageDealer.GetDamage();
        if (maxHealth <= 0f)
        {
            Destroy(gameObject);
        }
        damageDealer.Hit();
    }
}
