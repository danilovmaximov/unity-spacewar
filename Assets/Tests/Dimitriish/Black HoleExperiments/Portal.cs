using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
    
{
    public Transform PointOfDestination;
    // Start is called before the first frame update
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if ((other.attachedRigidbody.isKinematic == false)&&(other.attachedRigidbody != null))
        {
            other.gameObject.transform.position = PointOfDestination.position;
            other.attachedRigidbody.velocity = new Vector2(0,0);
        }
      
    }
}
