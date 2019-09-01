using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(0f, 40f)] float movementSpeed = 20f;
    [SerializeField] [Range(2, 6)] int numberOfFragments = 3;
    [SerializeField] GameObject nextLevelPrefab;
    [SerializeField] Sprite[] spriteVariants;
    [SerializeField] AudioClip shatterSound;

    // Cache
    private Rigidbody2D myRigidbody;

    private void Awake()
    {
        int variantIndex = Random.Range(0, spriteVariants.Length);
        GetComponentInChildren<SpriteRenderer>().sprite = spriteVariants[variantIndex];
    }

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

    public void Shatter()
    {
        if (nextLevelPrefab != null)
        {
            FindObjectOfType<AudioPlayer>().PlaySoundEffect(shatterSound);
            for (int i = 0; i < numberOfFragments; i++)
            {
                GameObject fragment = Instantiate(nextLevelPrefab, transform.position, Quaternion.identity) as GameObject;
            }
        }
    }
}
