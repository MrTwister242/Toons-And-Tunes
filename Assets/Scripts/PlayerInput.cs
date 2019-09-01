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
        if (Input.GetAxis("Vertical") > 0f)
        {
            playerMovement.ThrustForward();
        }

        else if (Input.GetAxis("Vertical") < 0f)
        {
            playerMovement.ThrustBackward();
        }

        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            playerMovement.FreezeMovementAndRotation();
        }

        else if (Input.GetAxis("Horizontal") < 0f)
        {
            playerMovement.IncreaseCounterClockwiseRotation();
        }

        else if (Input.GetAxis("Horizontal") > 0f)
        {
            playerMovement.IncreaseClockwiseRotation();
        }
                     
        playerMovement.Rotate();
    }

    private void Shoot()
    {
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
