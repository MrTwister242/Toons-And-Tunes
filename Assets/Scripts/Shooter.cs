using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Configuration
    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] [Range(100f, 500f)] float projectileSpeed = 250f;
    [SerializeField] [Range(0f, 3f)] float projectileFiringInterval = 0.2f;
    [SerializeField] [Range(0f, 2f)] float projectileFiringVariance = 0.5f;
    private bool shootAutomatically;

    [Header("Audio")]
    [SerializeField] AudioClip playerShootingSound;
    [SerializeField] AudioClip enemyShootingSound;

    // State
    private Coroutine shootingCoroutine;


    private void Start()
    {
        PlayerInput player = GetComponent<PlayerInput>();
        if(player != null)
        {
            shootAutomatically = false;
        }
        else
        {
            shootAutomatically = true;
        }
        ToggleShooting(shootAutomatically);
    }

    public void ToggleShooting(bool active)
    {
        if (active)
        {
            shootingCoroutine = StartCoroutine(ShootContinuously());
        }
        else if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
        }
    }

    IEnumerator ShootContinuously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, projectileSpeed));
            if (shootAutomatically)
            {
                FindObjectOfType<AudioPlayer>().PlaySoundEffect(enemyShootingSound);
            }
            else
            {
                FindObjectOfType<AudioPlayer>().PlaySoundEffect(playerShootingSound);
            }
            float timeBetweenShots = projectileFiringInterval + (shootAutomatically ? projectileFiringVariance : 0f);
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
