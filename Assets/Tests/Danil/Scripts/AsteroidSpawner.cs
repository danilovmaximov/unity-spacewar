using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    /*
     *  This script is used to spawn asteroids in random positions out of camera's sight.
     */

    public GameObject[] asteroidPrefabs;

    private Camera currentCamera;
    private float screenAspect;
    private float cameraBorderX = 0, cameraBorderY = 0;

    private float[] asteroidCoordinatesX, asteroidCoordinatesY;
    private float asteroidSpeed = 6f;
    float x = 0, y = 0;  // position where to spawn an asteroid
    int asteroidCoordinatesIndex = 0;  // random index used to find spawning position

    bool generationFinished = true; // trigger for generation, otherwise waiting doesn't work

    private void Awake()
    {
        currentCamera = FindObjectOfType<Camera>();
        screenAspect = (float)Screen.width / Screen.height;
        cameraBorderY = currentCamera.transform.position.y + currentCamera.orthographicSize + 1;
        cameraBorderX = currentCamera.transform.position.x + currentCamera.orthographicSize * screenAspect + 1;
        asteroidCoordinatesX = new float[] { cameraBorderX, -cameraBorderX };
        asteroidCoordinatesY = new float[] { cameraBorderY, -cameraBorderY };
    }

    IEnumerator SpawnAsteroid()
    {
        generationFinished = false;
        yield return new WaitForSeconds(1);

        /* Randomly picks an asteroid spawn position */
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            x = Random.Range(-cameraBorderX, cameraBorderX + 1);
            asteroidCoordinatesIndex = Random.Range(0, 2);
            y = asteroidCoordinatesY[asteroidCoordinatesIndex];
        }
        else
        {
            y = Random.Range(-cameraBorderY, cameraBorderY + 1);
            asteroidCoordinatesIndex = Random.Range(0, 2);
            x = asteroidCoordinatesX[asteroidCoordinatesIndex];
        }

        GameObject clone = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], new Vector3(x, y, 0), Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        Rigidbody2D cloneRb;

        Vector3 aim = new Vector3(Random.Range(-cameraBorderX, cameraBorderX + 1), Random.Range(-cameraBorderY, cameraBorderY + 1), 0);
        Vector3 direction = (aim - clone.transform.position).normalized;
        cloneRb = clone.GetComponent<Rigidbody2D>();
        cloneRb.velocity = new Vector2(direction.x * asteroidSpeed, direction.y * asteroidSpeed);

        generationFinished = true;
    }

    /* The main void of the script, is passed to the MainController */
    public void SpawnAsteroids()
    {
        if (generationFinished == true)
        {
            StartCoroutine(SpawnAsteroid());
        }
    }
}
