using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This is an unfinished script used to render and control players' lives.
 */

namespace Components
{
    public class Lives : MonoBehaviour
    {
        public Player player;
        public Enemy enemy;

        private Camera camera;

        void Awake()
        {
            camera = FindObjectOfType<Camera>();

            int offsetX = 35;
            int offsetY = 50;
            
            for (int i = 0; i < player.healthIcons.Length; i++)
            {
                playerHealthIcons[i] = Instantiate(playerHealthIcon, new Vector3(0, 0, 0), Quaternion.identity);
                playerHealthIcons[i].transform.SetParent(playerHealthPanel.transform);
                RectTransform rt = playerHealthIcons[i].GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector3(offsetX * i, offsetY, 0);
                playerHealthIcons[i].transform.localScale = new Vector3(1, 1, 1);
                playerHealthIcons[i].name = "Player Health Icon";
            }

            for (int i = 0; i < enemyHealthIcons.Length; i++)
            {
                enemyHealthIcons[i] = Instantiate(enemyHealthIcon, new Vector3(0, 0, 0), Quaternion.identity);
                enemyHealthIcons[i].transform.SetParent(enemyHealthPanel.transform);
                RectTransform rt = enemyHealthIcons[i].GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector3(Screen.width - (offsetX * (i + 1)), offsetY, 0);
                enemyHealthIcons[i].transform.localScale = new Vector3(1, 1, 1);
                enemyHealthIcons[i].name = "Enemy Health Icon";
            }

            ShipResources.OnShipDie += NotifyDeath;
        }
    }
}
