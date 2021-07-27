using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBlackHole : MonoBehaviour
{
    private HashSet<Rigidbody2D> AllObjects = new HashSet<Rigidbody2D>();
    private Rigidbody2D ThisBody = new Rigidbody2D();
    private GameObject ThisGO;
    private void Start()
    {
        ThisBody = GetComponent<Rigidbody2D>();
        ThisGO = gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody != null)
        {
            AllObjects.Add(other.attachedRigidbody);
        }
        Debug.Log("URA");
    }

    public void gravity()
    {
        foreach (Rigidbody2D body in AllObjects)
        {
            //Vector2 forceDirection = (ThisGO.transform.position - body.position).normalized;
            Vector2 forceDirection = (ThisBody.transform.position - body.transform.position);
            float distanceSqr = (ThisBody.transform.position - body.transform.position).sqrMagnitude;
            float strength = 2 * ThisBody.mass * body.mass / distanceSqr;

            if (body.isKinematic == false) body.AddForce(-forceDirection * strength);

        }


    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody != null)
        {
            AllObjects.Remove(other.attachedRigidbody);
        }
    }

}
