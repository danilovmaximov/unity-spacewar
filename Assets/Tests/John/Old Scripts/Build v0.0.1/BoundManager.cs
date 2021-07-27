using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagerComponents
{
public class BoundManager
{
    /** ===== Teleportation Bounds ===== **/
    /** ================================ **/

    /** Prefabs **/
    /** ======= **/

    public GameObject UpperTeleportationBound;
    public GameObject BottomTeleportationBound;
    public GameObject LeftTeleportationBound;
    public GameObject RightTeleportationBound;

    /** Colliders **/
    /** ========= **/

    private BoxCollider2D UpperTeleportationCollider;
    private BoxCollider2D BottomTeleportationCollider;
    private BoxCollider2D LeftTeleportationCollider;
    private BoxCollider2D RightTeleportationCollider;



    /** ===== Incineration Bounds Prefabs ===== **/
    /** ======================================= **/

    /** Prefabs **/
    /** ======= **/

    public GameObject UpperIncinerationBound;
    public GameObject BottomIncinerationBound;
    public GameObject LeftIncinerationBound;
    public GameObject RightIncinerationBound;

    /** Colliders **/
    /** ========= **/

    private BoxCollider2D UpperIncinerationCollider;
    private BoxCollider2D BottomIncinerationCollider;
    private BoxCollider2D LeftIncinerationCollider;
    private BoxCollider2D RightIncinerationCollider;

    

    /** ===== Initialize Bounds Game Objects ===== **/
    /** ========================================== **/

    /// <summary>
    /// Instantiating Teleportation and Incineration
    /// Bounds Game Objects, getting their BoxCollider2D
    /// components and changing their instances names.
    /// </summary>
    public void InitializeBoundsGameObjects()
    {
        /** Instantiating Teleportation Bounds **/
        /** ================================== **/

        UpperTeleportationBound = GameObject.Instantiate(Resources.Load("Prefabs/Bounds/UpperTeleportationBound", typeof(GameObject))) as GameObject;
        BottomTeleportationBound = GameObject.Instantiate(Resources.Load("Prefabs/Bounds/BottomTeleportationBound", typeof(GameObject))) as GameObject;
        LeftTeleportationBound = GameObject.Instantiate(Resources.Load("Prefabs/Bounds/LeftTeleportationBound", typeof(GameObject))) as GameObject;
        RightTeleportationBound = GameObject.Instantiate(Resources.Load("Prefabs/Bounds/RightTeleportationBound", typeof(GameObject))) as GameObject;


        /** Instantiating Incineration Bounds **/
        /** ================================= **/

        UpperIncinerationBound = GameObject.Instantiate(Resources.Load("Prefabs/Bounds/UpperIncinerationBound", typeof(GameObject))) as GameObject;
        BottomIncinerationBound = GameObject.Instantiate(Resources.Load("Prefabs/Bounds/BottomIncinerationBound", typeof(GameObject))) as GameObject;
        LeftIncinerationBound = GameObject.Instantiate(Resources.Load("Prefabs/Bounds/LeftIncinerationBound", typeof(GameObject))) as GameObject;
        RightIncinerationBound = GameObject.Instantiate(Resources.Load("Prefabs/Bounds/RightIncinerationBound", typeof(GameObject))) as GameObject;


        /** Getting Teleportation Bounds BoxCollider2D Components **/
        /** ===================================================== **/

        UpperTeleportationCollider = UpperTeleportationBound.GetComponent<BoxCollider2D>();
        BottomTeleportationCollider = BottomTeleportationBound.GetComponent<BoxCollider2D>();
        LeftTeleportationCollider = LeftTeleportationBound.GetComponent<BoxCollider2D>();
        RightTeleportationCollider = RightTeleportationBound.GetComponent<BoxCollider2D>();


        /** Getting Incineration Bounds BoxCollider2D Components **/
        /** ==================================================== **/

        UpperIncinerationCollider = UpperIncinerationBound.GetComponent<BoxCollider2D>();
        BottomIncinerationCollider = BottomIncinerationBound.GetComponent<BoxCollider2D>();
        LeftIncinerationCollider = LeftIncinerationBound.GetComponent<BoxCollider2D>();
        RightIncinerationCollider = RightIncinerationBound.GetComponent<BoxCollider2D>();


        /** Changing Teleportation Bounds Instances Names **/
        /** ============================================= **/

        UpperTeleportationBound.name = "UpperTeleportationBound";
        BottomTeleportationBound.name = "BottomTeleportationBound";
        LeftTeleportationBound.name = "LeftTeleportationBound";
        RightTeleportationBound.name = "RightTeleportationBound";


        /** Changing Incineration Bounds Instances Names **/
        /** ============================================ **/

        UpperIncinerationBound.name = "UpperIncinerationBound";
        BottomIncinerationBound.name = "BottomIncinerationBound";
        LeftIncinerationBound.name = "LeftIncinerationBound";
        RightIncinerationBound.name = "RightIncinerationBound";


        /** Disabling Bounds on Awake **/
        /** ========================= **/

        DisablingBounds();
    }



    /** ===== Setting Up Bounds ===== **/
    /** ============================= **/
    
    /// <summary>
    /// ...
    /// </summary>
    public void SettingUpBounds(BoxCollider2D playerCollider, float cameraWidth, float cameraHeight)
    {
        SettingUpTeleportationBounds(playerCollider, cameraWidth, cameraHeight);
        SettingUpIncinerationBounds(playerCollider, cameraWidth, cameraHeight);
    }



    /** ===== Setting Up Teleportation Bounds ===== **/
    /** =========================================== **/

    /// <summary>
    /// Changing the position, size and offset
    /// of teleportation bounds game objects.
    /// </summary>
    ///
    /// <todo>
    /// Give float values semantic wrapper (variable).
    /// </todo>
    public void SettingUpTeleportationBounds(BoxCollider2D playerCollider, float cameraWidth, float cameraHeight)
    {
        /** Changing the position of teleportation bounds **/
        /** ============================================= **/

        UpperTeleportationCollider.transform.position = new Vector3(0, cameraHeight/2.0f, 0);
        BottomTeleportationCollider.transform.position = new Vector3(0, -cameraHeight/2.0f, 0);
        LeftTeleportationCollider.transform.position = new Vector3(-cameraWidth/2.0f, 0, 0);
        RightTeleportationCollider.transform.position = new Vector3(cameraWidth/2.0f, 0, 0);


        /** Changing the size of teleportation bounds **/
        /** ========================================= **/

        UpperTeleportationCollider.size = new Vector2(cameraWidth + playerCollider.size.y, playerCollider.size.y/2.0f);
        BottomTeleportationCollider.size = new Vector2(cameraWidth + playerCollider.size.y, playerCollider.size.y/2.0f);
        LeftTeleportationCollider.size = new Vector2(playerCollider.size.y/2.0f, cameraHeight + playerCollider.size.y);
        RightTeleportationCollider.size = new Vector2(playerCollider.size.y/2.0f, cameraHeight + playerCollider.size.y);


        /** Changing the offset of teleportation bounds **/
        /** =========================================== **/

        UpperTeleportationCollider.offset = new Vector2(0, playerCollider.size.y/4.0f);
        BottomTeleportationCollider.offset = new Vector2(0, -playerCollider.size.y/4.0f);
        LeftTeleportationCollider.offset = new Vector2(-playerCollider.size.y/4.0f, 0);
        RightTeleportationCollider.offset = new Vector2(playerCollider.size.y/4.0f, 0);
    }



    /** ===== Setting Up Incineration Bounds ===== **/
    /** ========================================== **/

    /// <summary>
    /// Changing the position, size and offset
    /// of incineration bounds game objects.
    /// </summary>
    ///
    /// <todo>
    /// Give float values semantic wrapper (variable).
    /// </todo>
    public void SettingUpIncinerationBounds(BoxCollider2D playerCollider, float cameraWidth, float cameraHeight)
    {
        /** Changing the position of incineration bounds **/
        /** ============================================ **/

        UpperIncinerationCollider.transform.position = new Vector3(0, cameraHeight/2.0f + playerCollider.size.y, 0); // pc.s.y/2.0f
        BottomIncinerationCollider.transform.position = new Vector3(0, -cameraHeight/2.0f - playerCollider.size.y, 0); // pc.s.y/2.0f
        LeftIncinerationCollider.transform.position = new Vector3(-cameraWidth/2.0f - playerCollider.size.y, 0, 0); // pc.s.y/2.0f
        RightIncinerationCollider.transform.position = new Vector3(cameraWidth/2.0f + playerCollider.size.y, 0, 0); // pc.s.y/2.0f


        /** Changing the size of incineration bounds **/
        /** ======================================== **/

        UpperIncinerationCollider.size = new Vector2(cameraWidth + playerCollider.size.y, playerCollider.size.y/2.0f);
        BottomIncinerationCollider.size = new Vector2(cameraWidth + playerCollider.size.y, playerCollider.size.y/2.0f);
        LeftIncinerationCollider.size = new Vector2(playerCollider.size.y/2.0f, cameraHeight + playerCollider.size.y);
        RightIncinerationCollider.size = new Vector2(playerCollider.size.y/2.0f, cameraHeight + playerCollider.size.y);


        /** Changing the offset of incineration bounds **/
        /** ========================================== **/

        UpperIncinerationCollider.offset = new Vector2(0, UpperTeleportationCollider.size.y/2.0f);
        BottomIncinerationCollider.offset = new Vector2(0, -BottomTeleportationCollider.size.y/2.0f);
        LeftIncinerationCollider.offset = new Vector2(-LeftTeleportationCollider.size.x/2.0f, 0);
        RightIncinerationCollider.offset = new Vector2(RightTeleportationCollider.size.x/2.0f, 0);
    }



    /** ===== Disabling Bounds ===== **/
    /** ============================ **/

    public void DisablingBounds()
    {
        UpperTeleportationCollider.enabled = false;
        BottomTeleportationCollider.enabled = false;
        LeftTeleportationCollider.enabled = false;
        RightTeleportationCollider.enabled = false;

        UpperIncinerationCollider.enabled = false;
        BottomIncinerationCollider.enabled = false;
        LeftIncinerationCollider.enabled = false;
        RightIncinerationCollider.enabled = false;
    }

    /** ===== Enabling Bounds ===== **/
    /** =========================== **/

    public void EnablingBounds()
    {
        UpperTeleportationCollider.enabled = true;
        BottomTeleportationCollider.enabled = true;
        LeftTeleportationCollider.enabled = true;
        RightTeleportationCollider.enabled = true;

        UpperIncinerationCollider.enabled = true;
        BottomIncinerationCollider.enabled = true;
        LeftIncinerationCollider.enabled = true;
        RightIncinerationCollider.enabled = true;
    }
}
}
