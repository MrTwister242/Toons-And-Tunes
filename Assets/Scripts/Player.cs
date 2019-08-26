using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] public float movementSpeedIncrement = 25;
    [SerializeField] [Range(0, 100)] public float rotationSpeedIncrement = 50;
    [SerializeField] [Range(100, 300)] public float maximumRotationSpeed = 150;
    private float currentRotationSpeed;

    private void Start()
    {
        currentRotationSpeed = 0f;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, movementSpeedIncrement));
            currentRotationSpeed = 0f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, -movementSpeedIncrement));
            currentRotationSpeed = 0f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Mathf.Clamp(currentRotationSpeed += rotationSpeedIncrement, -maximumRotationSpeed, maximumRotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Mathf.Clamp(currentRotationSpeed -= rotationSpeedIncrement, -maximumRotationSpeed, maximumRotationSpeed);
        }

        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * currentRotationSpeed);
    }
}
