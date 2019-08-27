using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //TODO: Shooter class should not be taking input to allow use by enemies

    // Configuration
    [Header("All")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] [Range(100f, 500f)] float projectileSpeed = 250f;
    [SerializeField] [Range(0f, 3f)] float projectileFiringInterval = 0.2f;

    [Header("Enemies Only")]
    [SerializeField] [Range(0f, 2f)] float projectileFiringVariance = 0.5f;
    [SerializeField] bool shootAutomatically;

    // State
    private Coroutine shootingCoroutine;

    private void Start()
    {
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
            float timeBetweenShots = projectileFiringInterval + (shootAutomatically ? projectileFiringVariance : 0f);
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
