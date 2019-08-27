using UnityEngine;

/*  IMPORTANT:
 *  ----------
 *  This script uses Render.isVisible to disable colliders on all offscreen (foreground) objects
 *  A simple method to allow ghost objects for screen wrapping, without impacting collisions
 *  However, this doesn't work properly when the scene view is visible !  
 *  (Renderer.isVisible also considers the scene view camera)
 */


public class ScreenWrapper : MonoBehaviour
{
    // Configuration
    [SerializeField] GameObject mainObject;

    // State
    private Transform[] ghosts;
    private float screenWidth;
    private float screenHeight;


    private void Awake()
    {
        SetScreenDimensions();
        InstatiateGhosts();
    }

    private void Update()
    {
        RepositionParentToOnScreenChild();
        RepositionChildren();
        ToggleColliders();
    }

    private void SetScreenDimensions()
    {
        var cam = Camera.main;
        var screenBottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        var screenTopRight = cam.ViewportToWorldPoint(new Vector2(1, 1));
        screenWidth = screenTopRight.x - screenBottomLeft.x;
        screenHeight = screenTopRight.y - screenBottomLeft.y;
    }

    private void InstatiateGhosts()
    {
        ghosts = new Transform[8];
        for (int i = 0; i < 8; i++)
        {
            GameObject ghost = Instantiate(mainObject, this.transform) as GameObject;
            ghosts[i] = ghost.transform;
        }
    }

    private void RepositionParentToOnScreenChild()
    {
        foreach (Transform ghost in ghosts)
        {
            if (ghost.position.x < screenWidth/2 && ghost.position.x > -screenWidth/2 && ghost.position.y < screenHeight/2 && ghost.position.y > -screenHeight/2)
            {
                transform.position = ghost.position;
                break;
            }
        }
    }

    private void RepositionChildren()
    {
        mainObject.transform.position = transform.position;
        ghosts[0].position = new Vector2(transform.position.x + screenWidth, transform.position.y);
        ghosts[1].position = new Vector2(transform.position.x + screenWidth, transform.position.y - screenHeight);
        ghosts[2].position = new Vector2(transform.position.x, transform.position.y - screenHeight);
        ghosts[3].position = new Vector2(transform.position.x - screenWidth, transform.position.y - screenHeight);
        ghosts[4].position = new Vector2(transform.position.x - screenWidth, transform.position.y);
        ghosts[5].position = new Vector2(transform.position.x - screenWidth, transform.position.y + screenHeight);
        ghosts[6].position = new Vector2(transform.position.x, transform.position.y + screenHeight);
        ghosts[7].position = new Vector2(transform.position.x + screenWidth, transform.position.y + screenHeight);
    }

    private void ToggleColliders()
    {
        foreach (Transform ghost in ghosts)
        {
                ghost.GetComponent<PolygonCollider2D>().enabled = ghost.GetComponent<SpriteRenderer>().isVisible;
        }
    }
}
