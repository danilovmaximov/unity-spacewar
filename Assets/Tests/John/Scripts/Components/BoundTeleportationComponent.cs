using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Components
{
    public class BoundTeleportationComponent : MonoBehaviour
    {
        /** ===== Object Variables ===== **/
        /** ============================ **/

        public Rigidbody2D rigidbody;
        public BoxCollider2D collider;
        private List<GameObject> pool = new List<GameObject>();
        private string state;

        /** ===== Camera Bounds and Offsets ===== **/
        /** ===================================== **/

        private float CameraRightBoundMinOffset;
        private float CameraRightBoundMidOffset;
        private float CameraRightBoundMaxOffset;

        private float CameraLeftBoundMinOffset;
        private float CameraLeftBoundMidOffset;
        private float CameraLeftBoundMaxOffset;

        private float CameraUpperBoundMinOffset;
        private float CameraUpperBoundMidOffset;
        private float CameraUpperBoundMaxOffset;

        private float CameraBottomBoundMinOffset;
        private float CameraBottomBoundMidOffset;
        private float CameraBottomBoundMaxOffset;

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



        /** ===== Initialize Game Objects ====== **/
        /** ==================================== **/

        void Awake()
        {
            // Setting up Game Object
            collider = gameObject.GetComponent<BoxCollider2D>();
            rigidbody = gameObject.GetComponent<Rigidbody2D>();
            state = "Default";

            x_offset = collider.size.x / 2.0f;
            y_offset = collider.size.y / 2.0f;

            for(int i = 0; i < 3; i++)
            {
                GameObject reflection = GameObject.Instantiate(gameObject, new Vector3(
                    transform.position.x,
                    transform.position.y + 5.0f,
                    0.0f
                ), transform.rotation);
                reflection.name = gameObject.name + " reflection #" + (i+1);
                reflection.SetActive(false);
                pool.Add(reflection);
            }
        }



        /** ===== Check Game Object Position ===== **/
        /** ====================================== **/

        void Update()
        {
            // Setting up camera parameters (can do prettier/onCameraUpdate)
            cam_width = Camera.main.orthographicSize * Camera.main.aspect;
            cam_height = Camera.main.orthographicSize;

            // Setting up camera bounds (can do prettier/onCameraUpdate)
            // Setting up right camera bound offset
            CameraRightBoundMinOffset = cam_width - x_offset;
            CameraRightBoundMidOffset = cam_width;
            CameraRightBoundMaxOffset = cam_width + x_offset;
            // Setting up left...
            CameraLeftBoundMinOffset = -cam_width + x_offset;
            CameraLeftBoundMidOffset = -cam_width;
            CameraLeftBoundMaxOffset = -cam_width - x_offset;
            // You get the idea...
            CameraUpperBoundMinOffset = cam_height - y_offset;
            CameraUpperBoundMidOffset = cam_height;
            CameraUpperBoundMaxOffset = cam_height + y_offset;
            // ...
            CameraBottomBoundMinOffset = -cam_height + y_offset;
            CameraBottomBoundMidOffset = -cam_height;
            CameraBottomBoundMaxOffset = -cam_height - y_offset;


            // Resetting flags for checking off-camera events
            CameraBottomBound = false;
            CameraUpperBound = false;
            CameraLeftBound = false;
            CameraRightBound = false;

            if(gameObject.transform.position.x >= CameraRightBoundMinOffset){
                CameraRightBound = true;
            } else if(gameObject.transform.position.x <= CameraLeftBoundMinOffset){
                CameraLeftBound = true;
            } if(gameObject.transform.position.y >= CameraUpperBoundMinOffset){
                CameraUpperBound = true;
            } else if(gameObject.transform.position.y <= CameraBottomBoundMinOffset){
                CameraBottomBound = true;
            }


            // If we doesn't detect any collisions
            // with teleportation bounds, then we
            // really need to make sure every each of
            // player reflections in player pool must
            // be disabled and player's tag "Player"
            // is returned to him, so he could use
            // teleportation bound again...
            if(!CameraRightBound &&
            !CameraLeftBound &&
            !CameraUpperBound &&
            !CameraBottomBound){
                DisableReflections();
                state = "Default";
            }



            // These are the rules for Upper, Bottom, Left,
            // Right Bounds, and also for combinations,
            // such as (Upper/Left), (Upper/Right),
            // (Bottom/Left), (Bottom/Right). In the
            // simplest one we only creating (enabling)
            // one reflection of player. In more complex,
            // which are happening during screen angle
            // collisions, we creating three more reflections
            // on different sides of the screen.
            // Angle Case Detection
            if(CameraUpperBound && CameraRightBound && state != "AngleReflectable")
            {
                SetReflections(
                    // Make it variable, dude, WTF, why I need to read this fucking thing?..
                    // I can't fucking get it!
                    CameraLeftBoundMidOffset - (CameraRightBoundMidOffset - transform.position.x),
                    CameraBottomBoundMidOffset - (CameraUpperBoundMidOffset - transform.position.y),
                    4, 0);
                SetReflections(
                    CameraLeftBoundMidOffset - (CameraRightBoundMidOffset - transform.position.x),
                    transform.position.y,
                    4, 1);
                SetReflections(
                    transform.position.x,
                    CameraBottomBoundMidOffset - (CameraUpperBoundMidOffset - transform.position.y),
                    4, 2);
            }
            else if(CameraUpperBound && CameraLeftBound && state != "AngleReflectable")
            {
                SetReflections(
                    CameraRightBoundMidOffset - (CameraLeftBoundMidOffset - transform.position.x),
                    CameraBottomBoundMidOffset - (CameraUpperBoundMidOffset - transform.position.y),
                    4, 0);
                SetReflections(
                    CameraRightBoundMidOffset - (CameraLeftBoundMidOffset - transform.position.x),
                    transform.position.y,
                    4, 1);
                SetReflections(
                    transform.position.x,
                    CameraBottomBoundMidOffset - (CameraUpperBoundMidOffset - transform.position.y),
                    4, 2);
            }
            if(CameraBottomBound && CameraRightBound && state != "AngleReflectable")
            {
                SetReflections(
                    CameraLeftBoundMidOffset - (CameraRightBoundMidOffset - transform.position.x),
                    CameraUpperBoundMidOffset - (CameraBottomBoundMidOffset - transform.position.y),
                    4, 0);
                SetReflections(
                    CameraLeftBoundMidOffset - (CameraRightBoundMidOffset - transform.position.x),
                    transform.position.y,
                    4, 1);
                SetReflections(
                    transform.position.x,
                    CameraUpperBoundMidOffset - (CameraBottomBoundMidOffset - transform.position.y),
                    4, 2);
            }
            else if(CameraBottomBound && CameraLeftBound && state != "AngleReflectable")
            {
                SetReflections(
                    CameraRightBoundMidOffset - (CameraLeftBoundMidOffset - transform.position.x),
                    CameraUpperBoundMidOffset - (CameraBottomBoundMidOffset - transform.position.y),
                    4, 0);
                SetReflections(
                    CameraRightBoundMidOffset - (CameraLeftBoundMidOffset - transform.position.x),
                    transform.position.y,
                    4, 1);
                SetReflections(
                    transform.position.x,
                    CameraUpperBoundMidOffset - (CameraBottomBoundMidOffset - transform.position.y),
                    4, 2);
            }

            // Board Case Detection
            if(CameraUpperBound && !CameraLeftBound && !CameraRightBound && (state == "Default" || state == "AngleReflectable"))
            {
                DisableReflections();
                SetReflections(transform.position.x, CameraBottomBoundMidOffset - (CameraUpperBoundMidOffset - transform.position.y), 0);
            }
            else if(CameraBottomBound && !CameraLeftBound && !CameraRightBound && (state == "Default" || state == "AngleReflectable"))
            {
                DisableReflections();
                SetReflections(transform.position.x, CameraUpperBoundMidOffset - (CameraBottomBoundMidOffset - transform.position.y), 1);
            }
            if(CameraLeftBound && !CameraUpperBound && !CameraBottomBound && (state == "Default" || state == "AngleReflectable"))
            {
                DisableReflections();
                SetReflections(CameraRightBoundMidOffset - (CameraLeftBoundMidOffset - transform.position.x), transform.position.y, 2);
            }
            else if(CameraRightBound && !CameraUpperBound && !CameraBottomBound && (state == "Default" || state == "AngleReflectable"))
            {
                DisableReflections();
                SetReflections(CameraLeftBoundMidOffset - (CameraRightBoundMidOffset - transform.position.x), transform.position.y, 3);
            }
            
            // Player Offset Case Detection
            if(transform.position.x >= CameraRightBoundMaxOffset)
            {
                // We need it to make sure our player
                // doesn't collide with his reflection
                // during teleportation event
                pool[0].SetActive(false);
                // Just write something like...
                // Player.transform.position = PlayerPool[0].transform.position;
                // WTF is wrong with you, dude?..
                transform.position = new Vector3(pool[0].transform.position.x, pool[0].transform.position.y, 0.0f);
            }
            else if(transform.position.x <= CameraLeftBoundMaxOffset)
            {
                pool[0].SetActive(false);
                transform.position = new Vector3(pool[0].transform.position.x, pool[0].transform.position.y, 0.0f);
            }
            if(transform.position.y >= CameraUpperBoundMaxOffset)
            {
                pool[0].SetActive(false);
                transform.position = new Vector3(pool[0].transform.position.x, pool[0].transform.position.y, 0.0f);
            }
            else if(transform.position.y <= CameraBottomBoundMaxOffset)
            {
                pool[0].SetActive(false);
                transform.position = new Vector3(pool[0].transform.position.x, pool[0].transform.position.y, 0.0f);
            }
        }



        /** ===== Set Reflections ===== **/
        /** =========================== **/

        private void SetReflections(
            float x,       // X Axis Transform Position for Reflection
            float y,       // Y Axis Transform Position for Reflection
            int mode = -1, // Upper/Bottom/Left/Right Reflection Mode
            int index = 0  // Index of reflection in Player Pool
            )
        {
            // Setting the mode of the reflection.
            // It need for further functionality.
            switch (mode)
            {
                case 0:
                    state = "UpperReflectable";
                    break;
                case 1:
                    state = "BottomReflectable";
                    break;
                case 2:
                    state = "LeftReflectable";
                    break;
                case 3:
                    state = "RightReflectable";
                    break;
                case 4:
                    state = "AngleReflectable";
                    break;
            }

            // Setting the player's reflections position
            pool[index].transform.position = new Vector3(x, y, 0.0f);
            pool[index].transform.rotation = transform.rotation;
            pool[index].SetActive(true);
        }

        /** ===== Disable Reflections ===== **/
        /** =============================== **/

        private void DisableReflections()
        {
            foreach(GameObject reflection in pool)
            {
                reflection.transform.position = new Vector3(0.0f,0.0f,0.0f);
                reflection.SetActive(false);
            }
        }
    }
}
