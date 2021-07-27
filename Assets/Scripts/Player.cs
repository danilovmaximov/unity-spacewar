using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    protected override void Awake()
    {
        base.Awake();

        shipName = "Player";
        ShipResources.RegisterNewShip(shipName);

        shipSpawnPosition = new Vector3(-halfWidth + 5, 0, 0);
        healthIconPosition = new Vector3(-halfWidth + 2, halfHeight - 2, 0);
    }
}
