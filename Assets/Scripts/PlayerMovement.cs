using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(0f, 40f)] float movementSpeedIncrement = 20f;
    [SerializeField] [Range(0f, 10f)] float maximumForwardVelocity = 5f;
    [SerializeField] [Range(0f, 40f)] float rotationSpeedIncrement = 20f;
    [SerializeField] [Range(40f, 80f)] float maximumRotationSpeed = 60f;

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
        myRigidbody.AddRelativeForce(new Vector2(0, movementSpeedIncrement));
        float velocityX = Mathf.Clamp(myRigidbody.velocity.x, -maximumForwardVelocity, maximumForwardVelocity);
        float velocityY = Mathf.Clamp(myRigidbody.velocity.y, -maximumForwardVelocity, maximumForwardVelocity);
        myRigidbody.velocity = new Vector2(velocityX, velocityY);
        currentRotationSpeed = 0f;
    }

    public void ThrustBackward()
    {
        myRigidbody.AddRelativeForce(new Vector2(0, -movementSpeedIncrement));
        float velocityX = Mathf.Clamp(myRigidbody.velocity.x, -maximumForwardVelocity, maximumForwardVelocity);
        float velocityY = Mathf.Clamp(myRigidbody.velocity.y, -maximumForwardVelocity, maximumForwardVelocity);
        myRigidbody.velocity = new Vector2(velocityX, velocityY);
        currentRotationSpeed = 0f;
    }

    public void FreezeMovement()
    {
        myRigidbody.velocity = new Vector2(0, 0);
        currentRotationSpeed = 0f;
    }

    public void IncreaseCounterClockwiseRotation()
    {
        Mathf.Clamp(currentRotationSpeed += rotationSpeedIncrement, -maximumRotationSpeed, maximumRotationSpeed);
    }

    public void IncreaseClockwiseRotation()
    {
        Mathf.Clamp(currentRotationSpeed -= rotationSpeedIncrement, -maximumRotationSpeed, maximumRotationSpeed);
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * currentRotationSpeed);
    }

}
