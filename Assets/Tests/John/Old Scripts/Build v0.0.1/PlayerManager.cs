using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagerComponents
{
public class PlayerManager
{

    /** ===== Player Prefab ===== **/
    /** ========================= **/

    private GameObject Player;
    public Rigidbody2D PlayerRigidbody;
    public BoxCollider2D PlayerCollider;
    private List<GameObject> PlayerPool = new List<GameObject>();

    /** ===== Player States ===== **/
    /** ========================= **/

    private string PlayerState;

    /** ===== Player Buffer Values ===== **/
    /** ================================ **/

    private float playerBufferPosX;
    private float playerBufferPosY;
    private float playerDeltaPosX;
    private float playerDeltaPosY;

    /** ===== Player Movement Speed ===== **/
    /** ================================= **/

    private float playerMovementSpeed = 5.0f;
    private float playerRotationSpeed = 0.1125f;

    /** ===== Player Input Buffer ===== **/
    /** =============================== **/

    private float[] playerInputBuffer = new float[2];

    

    /** ===== Camera Off-Bound Event Flags ===== **/
    /** ======================================== **/

    bool CameraUpperBound = false;
    bool CameraBottomBound = false;
    bool CameraLeftBound = false;
    bool CameraRightBound = false;

    /** ===== Auxiliary Variables ===== **/
    /** =============================== **/

    float cam_width;
    float cam_height;
    float x_offset;
    float y_offset;
    



    /** ===== Initialize Players Game Object ===== **/
    /** ========================================== **/

    public void InitializePlayersGameObject(string PrefabName="PlayerObject")
    {
        // Setting up Player's Game Object
        Player = GameObject.Instantiate(Resources.Load("Prefabs/Player/" + PrefabName, typeof(GameObject))) as GameObject;
        PlayerCollider = Player.GetComponent<BoxCollider2D>();
        PlayerRigidbody = Player.GetComponent<Rigidbody2D>();
        Player.name = "Player";
        Player.tag = "Player";
        PlayerState = "Default";

        // Setting Offsets for Player Collider
        x_offset = PlayerCollider.size.x / 2.0f;
        y_offset = PlayerCollider.size.y / 2.0f;

        for(int i = 0; i < 3; i++)
        {
            GameObject PlayerReflection = GameObject.Instantiate(Player, new Vector3(
                Player.transform.position.x,
                Player.transform.position.y + 5.0f,
                0.0f
            ), Player.transform.rotation);
            PlayerReflection.name = "Player Reflection #" + (i+1);
            PlayerReflection.SetActive(false);
            PlayerPool.Add(PlayerReflection);
        }
    }

    public void GetPlayerInput()
    {
        playerInputBuffer[0] = Input.GetAxis("Horizontal");
        playerInputBuffer[1] = Input.GetAxis("Vertical");
    }



    /** ===== Update Player's Position ===== **/
    /** ==================================== **/

    public void UpdatePlayerPosition()
    {

        // Actually, it's better just to mimic player's
        // position. So I really need to rewrite it a little...
        foreach(GameObject Reflection in PlayerPool)
        {
            if(Reflection.activeSelf)
            {
                // Reflection.transform.Translate(0,  playerInputBuffer[1] * Time.deltaTime * playerMovementSpeed, 0);
                // Reflection.transform.Rotate(0, 0, -playerInputBuffer[0] * playerRotationSpeed / Time.deltaTime);
                Reflection.transform.position = new Vector3(
                    Reflection.transform.position.x + playerDeltaPosX,
                    Reflection.transform.position.y + playerDeltaPosY, 0.0f);
                Reflection.transform.rotation = Player.transform.rotation;
            }
        }
    }

    /** ===== Setting Up Scale ===== **/
    /** ============================ **/

    public void SettingUpScale(float aspectChangeProportion)
    {
        Player.transform.localScale = new Vector3(Player.transform.localScale.x * aspectChangeProportion, 1.0f, 1.0f);
    }
}
}
