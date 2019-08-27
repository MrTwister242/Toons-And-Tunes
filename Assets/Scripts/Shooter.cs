using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Configuration
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] [Range(100f, 500f)] float projectileSpeed = 250f;
    [SerializeField] [Range(0f, 1f)] float projectileFiringInterval = 0.2f;

    // State
    private Coroutine shootingCoroutine;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootingCoroutine = StartCoroutine(ShootContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
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
            yield return new WaitForSeconds(projectileFiringInterval);
        }
    }
}
