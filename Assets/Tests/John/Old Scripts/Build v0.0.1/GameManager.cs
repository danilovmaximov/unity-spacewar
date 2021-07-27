using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerComponents;

public class GameManager : MonoBehaviour
{

    /** ===== Manager Scripts ===== **/
    /** =========================== **/

    private CameraManager cameraManager;
    private ScreenManager screenManager;
    private DebugManager debugManager;
    private PlayerManager playerManager;
    private BoundManager boundManager;



    /** ===== Manager Flags ===== **/
    /** ========================= **/

    private bool screenSizeChangeCheck = false;
    private bool cameraSizeChangeCheck = false;
    private bool cameraAspectChangeCheck = false;



    /// <summary>
    /// Event function, called for each object in the scene at the time when the scene loads.
    /// All the `Awakes` will have finished before the first `Start` is called.
    /// </summary>
    void Awake()
    {
        cameraManager = new GameManagerComponents.CameraManager();
        screenManager = new GameManagerComponents.ScreenManager();
        debugManager = new GameManagerComponents.DebugManager();
        playerManager = new GameManagerComponents.PlayerManager();
        boundManager = new GameManagerComponents.BoundManager();

        cameraManager.InitializeCameraProperties();
        screenManager.InitializeScreenProperties();
        debugManager.InitializeDebugWindow();

        // First we need to inialize bounds objects
        // because player should use them to detect
        // collisions further in the game
        boundManager.InitializeBoundsGameObjects();
        playerManager.InitializePlayersGameObject();
        boundManager.SettingUpBounds(
            playerManager.PlayerCollider,
            cameraManager.cameraWidth,
            cameraManager.cameraHeight
        );
        // This is basic aspect ratio for 16/9 (16.0f/9.0f)
        // This scale is really affceting only X axis of player
        // game object, so we can change it however we like, and
        // whenever we like.
        playerManager.SettingUpScale(cameraManager.cameraAspect / 1.777108f);
    }



    /// <summary>
    /// ...
    /// </summary>
    void Start()
    {
        // Delayed Enabling Bounds
        StartCoroutine(LateStart(0.1f));   
    }


    /// <summary>
    /// There was a problem with Awake/Start and
    /// FixedUpdate. OnOverlapCollision of Player
    /// object was detecting collision with bounds
    /// in the very beginning of the game, so...
    /// the problem was that they were in the 0,0,0
    /// position of game world, I think. And only
    /// then they would change their position,
    /// according to script. Problem was that
    /// somehow FixedUpdate fired too soon, even
    /// sooner than Awake/Start functions ended.
    ///
    /// So, I figured, if we could wait just a little
    /// time more, than average FixedUpdate, we could
    /// activate colliders on bounds after first fire
    /// of the FixedUpdate, and when positions of
    /// bounds would take their righteous place,
    /// and no false collision firing at the start.
    /// </summary>
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        boundManager.EnablingBounds();
    }



    /// <summary>
    /// ...
    /// </summary>
    void Update()
    {

        // If cameras size or aspect has changed,
        // reset and recalculate bounds properties.
        // 
        // UPD. Okey, there was a problem. I just
        // found out very strange C# behaviour when
        // you do `if` statements with `or` stuff.
        // Whenever one of these statements is `True`,
        // it executes conditional function, so...
        // firstly it executes after the first OR
        // statement (camera size change check), and
        // only then it checks other OR statements.
        // Which creates problem, because my aspect
        // ratio doesn't updates in time, and also...
        // IT EXECUTES THREE TIMES IN A ROW!!!!!
        // 
        // UPD. Adding new variables and executing check
        // functions before if statement solves problem.

        screenSizeChangeCheck = screenManager.ScreenSizeChangeCheck();
        cameraSizeChangeCheck = cameraManager.CameraSizeChangeCheck();
        cameraAspectChangeCheck = cameraManager.CameraAspectChangeCheck();

        if(screenSizeChangeCheck || cameraSizeChangeCheck || cameraAspectChangeCheck)
        {
            if(cameraAspectChangeCheck)
            {
                // Aspect Ratio changes unpredictably whenever you changing size of the screen, and etc.
                // I think, it's better to follow changing of the aspect and adjust player size manually.
                playerManager.SettingUpScale(cameraManager.GetCameraAspectChangeProportion());
            }
            
            boundManager.SettingUpBounds(
                playerManager.PlayerCollider,
                cameraManager.cameraWidth,
                cameraManager.cameraHeight
            );
        }

        // Updating Player's Position
        playerManager.GetPlayerInput();

        // Updating Debug Text
        debugManager.AppendDebugBuffer(screenManager.DebugScreenSize());
        debugManager.AppendDebugBuffer(cameraManager.DebugCameraSize());
        debugManager.AppendDebugBuffer(cameraManager.DebugCameraAspect());
        debugManager.UpdateDebugText();
    }
}
