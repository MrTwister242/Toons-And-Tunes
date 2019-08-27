using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //TODO: Shooting should move entirely to the Shooter class

    // Configuration
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] [Range(0f, 1f)] float minTimeBetweenShots = 0.2f;
    [SerializeField] [Range(1f, 5f)] float maxTimeBetweenShots = 3f;

    // State
    [SerializeField] float shotCounter;

    private void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();        
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
    }
}
