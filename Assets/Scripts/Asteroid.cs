using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(0f, 40f)] float movementSpeed = 20f;
    [SerializeField] [Range(0, 3)] int level = 3;
    [SerializeField] [Range(2, 6)] int numberOfFragments = 3;
    [SerializeField] List<Sprite> asteroidLevelSprites;
    [SerializeField] GameObject asteroidPrefab;

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

    //TODO: not working correctly
    private void OnDestroy()
    {
        Debug.Log("test ondestroy");
        if (level > 0)
        {
            for (int i = 0; i < numberOfFragments; i++)
            {
                GameObject fragment = Instantiate(asteroidPrefab, this.transform) as GameObject;
                fragment.GetComponent<Asteroid>().level = level - 1;
                fragment.GetComponentInChildren<SpriteRenderer>().sprite = asteroidLevelSprites[level];
            }
        }
    }

}
