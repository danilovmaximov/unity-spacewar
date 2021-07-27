using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingBounds : MonoBehaviour
{

    /*
     *  This script spawns bounds (rectangles) out of camera's sight, which destroy
     *  incoming asteroids, i.e. those that passed the gamefield without being destroyed.
     */

    private Camera currentCamera;

    private GameObject horizontalBound;
    private GameObject verticalBound;
    public Sprite boundSprite;

    float screenAspect = 0;

    // Creates prefabs of vertical and horizontal destroying bounds.
    public void CreateBoundsPrefabs()
    {
        /* Creating bounds prototypes according to the camera's size */
        currentCamera = FindObjectOfType<Camera>();
        screenAspect = (float)Screen.width / Screen.height;

        // Create new game objects and make them inactive
        horizontalBound = new GameObject();
        verticalBound = new GameObject();
        horizontalBound.SetActive(false);
        verticalBound.SetActive(false);

        // Add SpriteRenderer components to each of the objects and acquire the bounds' sprites
        SpriteRenderer horizontalSprite = horizontalBound.AddComponent<SpriteRenderer>();
        SpriteRenderer verticalSprite = verticalBound.AddComponent<SpriteRenderer>();
        horizontalSprite.sprite = boundSprite;
        verticalSprite.sprite = boundSprite;

        // Change objects' size accoring to their orientation
        horizontalBound.transform.localScale =
                    new Vector3(2 * currentCamera.orthographicSize * screenAspect + 6, 1, 1);
        verticalBound.transform.localScale =
                    new Vector3(1, 2 * currentCamera.orthographicSize + 6, 1);


        // Add colliders to the objects and make the colliders trigger-type.
        BoxCollider2D horizontalCollider = horizontalBound.AddComponent<BoxCollider2D>();
        BoxCollider2D verticalCollider = verticalBound.AddComponent<BoxCollider2D>();
        horizontalCollider.isTrigger = true;
        verticalCollider.isTrigger = true;

        // Add rigidbodies and make those kinematic
        Rigidbody2D horizontalRB = horizontalBound.AddComponent<Rigidbody2D>();
        Rigidbody2D verticalRB = verticalBound.AddComponent<Rigidbody2D>();
        horizontalRB.bodyType = RigidbodyType2D.Kinematic;
        verticalRB.bodyType = RigidbodyType2D.Kinematic;

        // Add script which controls borders in game's runtime
        horizontalBound.AddComponent<DestroyerBoundController>();
        verticalBound.AddComponent<DestroyerBoundController>();

        Debug.Log("Prefabs are ready");
    }

    // Creates instances of previously created prefab
    public void CreateDestroingBounds()
    {
        GameObject upperBound = Instantiate(horizontalBound, new Vector3(currentCamera.transform.position.x, currentCamera.transform.position.y + currentCamera.orthographicSize + 4, 0), Quaternion.identity);
        upperBound.name = "upperBound";
        upperBound.SetActive(true);

        GameObject lowerBound = Instantiate(horizontalBound, new Vector3(currentCamera.transform.position.x, currentCamera.transform.position.y - currentCamera.orthographicSize - 4, 0), Quaternion.identity);
        lowerBound.name = "lowerBound";
        lowerBound.SetActive(true);

        GameObject rightBound = Instantiate(verticalBound, new Vector3(currentCamera.transform.position.x + currentCamera.orthographicSize * screenAspect + 4, currentCamera.transform.position.y, 0), Quaternion.identity);
        rightBound.name = "rightBound";
        rightBound.SetActive(true);

        GameObject leftBound = Instantiate(verticalBound, new Vector3(currentCamera.transform.position.x - currentCamera.orthographicSize * screenAspect - 4, currentCamera.transform.position.y, 0), Quaternion.identity);
        leftBound.name = "leftBound";
        leftBound.SetActive(true);

        Destroy(verticalBound);
        Destroy(horizontalBound);

        Debug.Log("Bounds are created");
    }
}

class DestroyerBoundController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Small Asteroid" || collision.tag == "Big Asteroid") { Destroy(collision.gameObject); }
    }
}