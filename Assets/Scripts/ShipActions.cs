using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipActions : MonoBehaviour
{
    public Rigidbody2D shipRigidbody;
    public Transform shipTransform;
    public GameObject bulletPrefab;
    public GameObject shipGO;
    public float width;
    public  float height;
    private Camera currentCamera;
    float screenAspect;


    private void Start() {
        shipGO = gameObject;
        currentCamera = FindObjectOfType<Camera>();
        screenAspect = (float)Screen.width / Screen.height;
        width = currentCamera.orthographicSize * screenAspect;
        height = currentCamera.orthographicSize;
    }
    public void Accelerate(float input)
    {
        int accelerationForce = 3000;
        int maxSpeed = 2000;

        if (shipRigidbody.velocity.magnitude <= maxSpeed) shipRigidbody.AddForce(shipTransform.up * input * accelerationForce);
    }

    public void Rotate(float input)
    {
        int rotationForce = 1000;
        int rotationFriction = -20;

        shipRigidbody.AddTorque(-input * rotationForce);
        shipRigidbody.AddTorque(shipRigidbody.angularVelocity * rotationFriction);
    }

    public void Shoot()
    {
        bool gunAlternation = Random.value < 0.5f;
        float offsetToGun = 0.2f;

        switch (gunAlternation)
        {
            case true:
                Instantiate(bulletPrefab, shipTransform.position + shipTransform.right * offsetToGun, shipTransform.rotation);
                break;
            case false:
                Instantiate(bulletPrefab, shipTransform.position + shipTransform.right * (-offsetToGun), shipTransform.rotation);
                break;
        }
    }

    public void Die(string shipName)
    {
        int health = ShipResources.GetRegisteredShip(shipName);
        Debug.Log("Player trying to take his life with: " + health);

        // Отнимает жизнь
        ShipResources.ReduceHealth(shipName);
    }


    public void ActivationGO(){
        gameObject.SetActive(true);
    }

    public void Teleport(){
        gameObject.SetActive(false);
        Invoke("ActivationGO", 3f);
        gameObject.transform.position = new Vector2(Camera.main.transform.position.x + 2 *
                                        (Random.value - 0.5f) * width, Camera.main.transform.position.y + (Random.value - 0.5f) * height); 
    }
    
}
