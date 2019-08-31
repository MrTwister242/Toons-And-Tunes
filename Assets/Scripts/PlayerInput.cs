using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    // Cache
    private PlayerMovement playerMovement;
    private Shooter shooter;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            playerMovement.ThrustForward();
        }

        else if (Input.GetKey(KeyCode.S))
        {
            playerMovement.ThrustBackward();
        }

        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            playerMovement.FreezeMovement();
        }

        else if (Input.GetKey(KeyCode.Q))
        {
            playerMovement.IncreaseCounterClockwiseRotation();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            playerMovement.IncreaseClockwiseRotation();
        }

        playerMovement.Rotate();

    }

    private void Shoot()
    {
        //TODO: Sometimes player gets stuck in continuous shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooter.ToggleShooting(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shooter.ToggleShooting(false);
        }
    }

}
