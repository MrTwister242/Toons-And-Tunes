using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] [Range(0, 100)] public float movementSpeedIncrement = 50;
    [SerializeField] [Range(0, 100)] public float rotationSpeedIncrement = 50;
    [SerializeField] [Range(0, 100)] public float maximumRotationSpeed = 200;
    private float currentRotationSpeed;

    [Header("Screen Wrapping")]
    [SerializeField] public GameObject ghostPrefab;
    private Transform[] ghosts;

    private void Start()
    {
        currentRotationSpeed = 0f;

        PositionGhostShips();

    }

    private void PositionGhostShips()
    {
        var cam = Camera.main;
        var screenBottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        var screenTopRight = cam.ViewportToWorldPoint(new Vector2(1, 1));
        var screenWidth = screenTopRight.x - screenBottomLeft.x;
        var screenHeight = screenTopRight.y - screenBottomLeft.y;

        ghosts = new Transform[8];
        for (int i = 0; i < 8; i++)
        {
            GameObject ghost = Instantiate(ghostPrefab, this.transform) as GameObject;
            ghosts[i] = ghost.transform;
        }

        ghosts[0].position = new Vector2(transform.position.x + screenWidth, transform.position.y);
        ghosts[1].position = new Vector2(transform.position.x + screenWidth, transform.position.y - screenHeight);
        ghosts[2].position = new Vector2(transform.position.x, transform.position.y - screenHeight);
        ghosts[3].position = new Vector2(transform.position.x - screenWidth, transform.position.y - screenHeight);
        ghosts[4].position = new Vector2(transform.position.x - screenWidth, transform.position.y);
        ghosts[5].position = new Vector2(transform.position.x - screenWidth, transform.position.y + screenHeight);
        ghosts[6].position = new Vector2(transform.position.x, transform.position.y + screenHeight);
        ghosts[7].position = new Vector2(transform.position.x + screenWidth, transform.position.y + screenHeight);
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
