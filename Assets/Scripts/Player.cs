using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(0, 40)] public float movementSpeedIncrement = 20f;
    [SerializeField] [Range(0, 10)] public float maximumForwardVelocity = 5f;
    [SerializeField] [Range(0, 40)] public float rotationSpeedIncrement = 20f;
    [SerializeField] [Range(40, 80)] public float maximumRotationSpeed = 60f;
    private float currentRotationSpeed;
    private Rigidbody2D myRigidbody;

    private void Start()
    {
        currentRotationSpeed = 0f;
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        Move();
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
}
