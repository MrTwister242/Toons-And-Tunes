using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] [Range(0, 100)] public float movementSpeedIncrement = 50;
    [SerializeField] [Range(0, 100)] public float rotationSpeedIncrement = 50;
    [SerializeField] [Range(0, 100)] public float maximumRotationSpeed = 200;
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
        //var deltaX = Input.GetAxis("Horizontal");
        //var deltaY = Input.GetAxis("Vertical");
        //var newXPos = transform.position.x + deltaX;
        //var newYPos = transform.position.y + deltaY;
        //transform.position = new Vector2(newXPos, newYPos);



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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Mathf.Clamp(currentRotationSpeed += rotationSpeedIncrement, -maximumRotationSpeed, maximumRotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Mathf.Clamp(currentRotationSpeed -= rotationSpeedIncrement, -maximumRotationSpeed, maximumRotationSpeed);
        }

        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * currentRotationSpeed);

    }
}
