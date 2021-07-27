using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This script is used to control asteroinds' collisions and proceed to despawn/explostion.
 */

public class AsteroidCollisionController : MonoBehaviour
{
    public GameObject[] AsteroidPrefabs;

    private Rigidbody2D asteroidRB;
    private Animator asteroidAnimator;

    public float MinimalVelocityForCollision = 2f;

    private void Start()
    {
        asteroidRB = GetComponent<Rigidbody2D>();
        asteroidAnimator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D otherRB = collision.gameObject.GetComponent<Rigidbody2D>();

        float xImpact = asteroidRB.velocity.normalized.x + otherRB.velocity.normalized.x;
        float yImpact = asteroidRB.velocity.normalized.y + otherRB.velocity.normalized.y;
        // bool enoughSpeed => asteroidRB.velocity.x > MinimalVelocityForCollision;

        Debug.Log("Collision found!" + " x: " + xImpact + " y: " + yImpact);

        if (System.Math.Abs(xImpact) < 0.5f || System.Math.Abs(yImpact) < 0.5f)
        {
            Debug.Log("That one fits.");
            if (gameObject.tag == "Small Asteroid")
            {
                RuntimeAnimatorController animatorController = asteroidAnimator.runtimeAnimatorController;
                float time = animatorController.animationClips[0].length;

                asteroidRB.bodyType = RigidbodyType2D.Static;
                StartCoroutine(ExplodeAsteroid(gameObject, time));
            }

            if (gameObject.tag == "Big Asteroid" && collision.gameObject.tag == "Big Asteroid")
            {
                CreateShards(gameObject);
            }
        }
    }

    private IEnumerator ExplodeAsteroid(GameObject self, float time)
    {
        self.GetComponent<Animator>().SetBool("isExploding", true);
        yield return new WaitForSeconds(time);
        Destroy(self);
    }

    private void CreateShards(GameObject self)
    {
        Rigidbody2D rigidbody = self.GetComponent<Rigidbody2D>();
        Transform transform = self.GetComponent<Transform>();

        for (int i = 0; i < 4; i++)
        {
            GameObject clone = Instantiate(AsteroidPrefabs[Random.Range(0, 3)], transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
            //clone.GetComponent<Rigidbody2D>().velocity = 
        }
        Destroy(self);
    }
}
