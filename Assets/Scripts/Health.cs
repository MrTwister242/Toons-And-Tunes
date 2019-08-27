using UnityEngine;

public class Health : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(100f, 500f)] float maxHealth = 250f;
    [SerializeField] Alliance alliance = Alliance.neutral;

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
        if(damageDealer.GetAlliance() != alliance)
        maxHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (maxHealth <= 0f)
        {
            //TODO: destruction animations - maybe shatter asteroids from here ?
            Destroy(gameObject);
        }

    }
}
