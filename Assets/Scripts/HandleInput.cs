using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput : MonoBehaviour
{
    public ShipActions shipActions;

    private KeyCode shootButton = KeyCode.Space;
    private KeyCode teleportButton = KeyCode.F;
    [SerializeField] private float accelerationInput;
    [SerializeField] private float rotationInput;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private bool canTeleport = true;

    private void Update()
    {
        accelerationInput = Input.GetAxisRaw("Vertical");
        rotationInput = Input.GetAxisRaw("Horizontal");

        shipActions.Accelerate(accelerationInput);
        shipActions.Rotate(rotationInput);

        if (Input.GetKeyDown(shootButton) && canShoot && gameObject.activeSelf)
        {
            shipActions.Shoot();
            StartCoroutine(ShootingCooldown());
        }

         if (Input.GetKeyDown(teleportButton) && canTeleport && gameObject.activeSelf)
        {
            //StartCoroutine(TeleportationCooldown());
            shipActions.Teleport();
        }
    }

    IEnumerator ShootingCooldown()
    {
        canShoot = !canShoot;
        yield return new WaitForSeconds(0.5f);
        canShoot = !canShoot;
    }


    IEnumerator TeleportationCooldown()
    {
        canTeleport = !canTeleport;
        yield return new WaitForSeconds(10f);
        canTeleport = !canTeleport;
    }
}