using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(0f, 40f)] public float movementSpeed = 20f;

    // Cache
    private Rigidbody2D myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        InitializeMovement();
    }

    private void InitializeMovement()
    {
        float rotationZ = Random.Range(0f, 360f);
        transform.Rotate(new Vector3(0, 0, rotationZ));
        myRigidbody.AddRelativeForce(transform.up * movementSpeed);
    }
}
