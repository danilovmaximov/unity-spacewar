using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Используемые компоненты
    public ShipActions shipActions;
    public Camera camera;

    // Используемые переменные
    [HideInInspector] public float halfWidth, halfHeight;

    // Свойства корабля
    public string shipName;
    public Vector3 shipSpawnPosition;

    // Переменные для отображения жизней
    public GameObject healthIcon;
    public Vector3 healthIconPosition;

    protected virtual void Awake()
    {
        float screenAspect = (float)Screen.width / Screen.height;
        halfWidth = camera.orthographicSize * screenAspect;
        halfHeight = camera.orthographicSize;
    }

    public void CreateShip()
    {
        gameObject.transform.position = shipSpawnPosition;
        gameObject.SetActive(true);
    }

    public void CreateHealthIcon()
    {
        healthIcon.transform.position = healthIconPosition;
        healthIcon.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shipActions.Die(shipName);
    }
}
