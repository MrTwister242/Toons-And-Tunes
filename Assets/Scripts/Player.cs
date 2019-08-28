using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(0f, 40f)] float movementSpeedIncrement = 20f;
    [SerializeField] [Range(0f, 10f)] float maximumForwardVelocity = 5f;
    [SerializeField] [Range(0f, 40f)] float rotationSpeedIncrement = 20f;
    [SerializeField] [Range(40f, 80f)] float maximumRotationSpeed = 60f;

    // Cache
    private Rigidbody2D myRigidbody;
    private Shooter shooter;

    // State
    private float currentRotationSpeed;

    private void Start()
    {
        currentRotationSpeed = 0f;
        myRigidbody = GetComponent<Rigidbody2D>();
        shooter = GetComponent<Shooter>();
    }

    private void LateUpdate()
    {
        Move();
        Shoot();
    }

    private void Move()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            myRigidbody.AddRelativeForce(new Vector2(0, movementSpeedIncrement));
            float velocityX = Mathf.Clamp(myRigidbody.velocity.x, -maximumForwardVelocity, maximumForwardVelocity);
            float velocityY = Mathf.Clamp(myRigidbody.velocity.y, -maximumForwardVelocity, maximumForwardVelocity);
            myRigidbody.velocity = new Vector2(velocityX, velocityY);
            currentRotationSpeed = 0f;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            myRigidbody.AddRelativeForce(new Vector2(0, -movementSpeedIncrement));
            float velocityX = Mathf.Clamp(myRigidbody.velocity.x, -maximumForwardVelocity, maximumForwardVelocity);
            float velocityY = Mathf.Clamp(myRigidbody.velocity.y, -maximumForwardVelocity, maximumForwardVelocity);
            myRigidbody.velocity = new Vector2(velocityX, velocityY);
            currentRotationSpeed = 0f;
        }

        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            myRigidbody.velocity = new Vector2(0, 0);
            currentRotationSpeed = 0f;
        }

        else if (Input.GetKey(KeyCode.Q))
        {
            Mathf.Clamp(currentRotationSpeed += rotationSpeedIncrement, -maximumRotationSpeed, maximumRotationSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Mathf.Clamp(currentRotationSpeed -= rotationSpeedIncrement, -maximumRotationSpeed, maximumRotationSpeed);
        }

        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * currentRotationSpeed);
    }

    private void Shoot()
    {
        //TODO: Sometimes player gets stuck in continuous shooting
        if (Input.GetButtonDown("Fire1"))
        {
            shooter.ToggleShooting(true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            shooter.ToggleShooting(false);
        }
    }

}
