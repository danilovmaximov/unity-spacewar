using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Camera currentCamera;
    float screenAspect = (float)Screen.width / Screen.height;
    private bool isOutOfBounds;
    private float outOfBoundsOffset = 1.2f;

    public float width;
    public float height;
    public Transform bulletTransform;
    public float bulletSpeed = 0.25f;

    private void Start()
    {
        currentCamera = FindObjectOfType<Camera>();
        screenAspect = (float)Screen.width / Screen.height;
        width = currentCamera.orthographicSize * screenAspect;
        height = currentCamera.orthographicSize;
    }

    public void FixedUpdate()
    {
        isOutOfBounds = (Mathf.Abs(bulletTransform.position.x) > outOfBoundsOffset * width)
                     || (Mathf.Abs(bulletTransform.position.y) > outOfBoundsOffset * height);

        bulletTransform.position += bulletTransform.up * bulletSpeed;

        if (isOutOfBounds)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // give damage if it's the player
    }
}
