using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(0f, 500f)] float movementSpeedIncrement = 200f;
    [SerializeField] [Range(0f, 20f)] float maximumForwardVelocity = 10f;
    [SerializeField] [Range(0f, 500f)] float rotationSpeedIncrement = 200f;
    [SerializeField] [Range(20f, 40f)] float maximumRotationSpeed = 30f;

    // Cache
    private Rigidbody2D myRigidbody;

    // State
    private float currentRotationSpeed;

    private void Start()
    {
        currentRotationSpeed = 0f;
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void ThrustForward()
    {
        myRigidbody.AddRelativeForce(new Vector2(0, movementSpeedIncrement) * Time.deltaTime);
        float velocityX = Mathf.Clamp(myRigidbody.velocity.x, -maximumForwardVelocity, maximumForwardVelocity);
        float velocityY = Mathf.Clamp(myRigidbody.velocity.y, -maximumForwardVelocity, maximumForwardVelocity);
        myRigidbody.velocity = new Vector2(velocityX, velocityY);
        currentRotationSpeed = 0f;
    }

    public void ThrustBackward()
    {
        myRigidbody.AddRelativeForce(new Vector2(0, -movementSpeedIncrement) * Time.deltaTime);
        float velocityX = Mathf.Clamp(myRigidbody.velocity.x, -maximumForwardVelocity, maximumForwardVelocity);
        float velocityY = Mathf.Clamp(myRigidbody.velocity.y, -maximumForwardVelocity, maximumForwardVelocity);
        myRigidbody.velocity = new Vector2(velocityX, velocityY);
        currentRotationSpeed = 0f;
    }

    public void FreezeMovementAndRotation()
    {
        myRigidbody.velocity = new Vector2(0, 0);
        currentRotationSpeed = 0f;
    }

    public void IncreaseCounterClockwiseRotation()
    {
        Mathf.Clamp(currentRotationSpeed += rotationSpeedIncrement * Time.deltaTime, -maximumRotationSpeed, maximumRotationSpeed);
    }

    public void IncreaseClockwiseRotation()
    {
        Mathf.Clamp(currentRotationSpeed -= rotationSpeedIncrement * Time.deltaTime, -maximumRotationSpeed, maximumRotationSpeed);
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * currentRotationSpeed);
    }

}
