using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Configuration
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] [Range(100f, 500f)] float projectileSpeed = 250f;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, projectileSpeed));
            //TODO: add cooldown between projectiles
        }
    }
}
