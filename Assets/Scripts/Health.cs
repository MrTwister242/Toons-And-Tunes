using UnityEngine;

public class Health : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(100f, 500f)] float maxHealth = 250f;
    [SerializeField] Alliance alliance = Alliance.neutral;
    [SerializeField] [Range(100f, 2000f)] float scoreValue = 500f;
    [SerializeField] AudioClip deathSound;

    // State
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    //TODO: check weird behaviour after asteroid collisions (forces applied when reaching edge of the screen ?)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            ProcessHit(damageDealer);
        }
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
        {
            currentHealth -= damageDealer.GetDamage();
            damageDealer.Hit();
            if (currentHealth <= 0f)
            {
                PlayerInput player = GetComponent<PlayerInput>();
                if (player != null)
                {
                    Destroy(gameObject);
                    FindObjectOfType<GameSession>().PlayerDies();
                    FindObjectOfType<AudioPlayer>().PlaySoundEffect(deathSound);
                    //TODO: add delay
                }
                else
                {
                    FindObjectOfType<GameSession>().IncreaseScore(scoreValue);
                    //TODO: destruction animations
                    Asteroid asteroid = GetComponent<Asteroid>();
                    if (asteroid != null)
                    {
                        asteroid.Shatter();

                    }
                    Destroy(gameObject);
                }

            }
        }

    }

    public Alliance GetAlliance()
    {
        return alliance;
    }
}
