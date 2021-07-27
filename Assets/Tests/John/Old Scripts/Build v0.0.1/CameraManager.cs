using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagerComponents
{
public class CameraManager
{
    /** ===== Main Camera Properties ====== **/
    /** =================================== **/

    /** Buffer Camera Properties **/
    /** ======================== **/

    private Camera mainCamera;
    public float cameraWidth;
    public float cameraHeight;
    public float cameraAspect;

    public float bufferCameraWidth;
    public float bufferCameraHeight;
    public float bufferCameraAspect;

    /** Current Camera Properties **/
    /** ========================= **/

    private float currentCameraWidth;
    private float currentCameraHeight;



    /** ===== Initialize Camera Properties ===== **/
    /** ======================================== **/

    /// <summary>
    /// Initializing camera game objects
    /// properties such as width, height,
    /// and aspect.
    /// </summary>
    public void InitializeCameraProperties()
    {
        mainCamera = Camera.main;
        cameraHeight = 2.0f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
        cameraAspect = mainCamera.aspect;
    }



    /** ===== Camera Size Change Check ===== **/
    /** ==================================== **/

    /// <summary>
    /// Changing the buffer camera size
    /// if current camera size changed.
    /// </summary>
    ///
    /// <todo>
    /// Make debugging tool, so we could
    /// see, how camera size have changed.
    /// </todo>
    public bool CameraSizeChangeCheck()
    {
        currentCameraHeight = 2.0f * mainCamera.orthographicSize;
        currentCameraWidth = currentCameraHeight * mainCamera.aspect;
        
        if(cameraHeight != currentCameraHeight ||
           cameraWidth != currentCameraWidth)
        {
            bufferCameraHeight = cameraHeight;
            bufferCameraWidth = cameraWidth;
            cameraHeight = currentCameraHeight;
            cameraWidth = currentCameraWidth;
            return true;
        }
        else
        {
            return false;
        }
    }

    /** ===== Camera Aspect Change Check ===== **/
    /** ====================================== **/

    /// <summary>
    /// Changing the buffer camera aspect
    /// if current camera aspect changed.
    /// </summary>
    ///
    /// <todo>
    /// Make debugging tool, so we could
    /// see, how camera size have changed.
    /// </todo>
    public bool CameraAspectChangeCheck()
    {
        if(cameraAspect != mainCamera.aspect)
        {
            bufferCameraHeight = cameraHeight;
            bufferCameraWidth = cameraWidth;
            bufferCameraAspect = cameraAspect;
            cameraHeight = 2.0f * mainCamera.orthographicSize;
            cameraWidth = currentCameraHeight * mainCamera.aspect;
            cameraAspect = mainCamera.aspect;
            return true;
        }
        else
        {
            return false;
        }
    }



    /** ===== Get Camera Aspect Change Proportions ===== **/
    /** ================================================ **/

    public float GetCameraAspectChangeProportion()
    {
        return cameraAspect / bufferCameraAspect;
    }



    /** ===== Get Camera Buffer Properties ===== **/
    /** ======================================== **/

    public float[] GetCameraBufferProperties()
    {
        return new float[] { bufferCameraHeight, bufferCameraWidth, bufferCameraAspect };
    }



    /** ===== Debug Camera Size ===== **/
    /** ============================= **/

    /// <summary>
    /// ...
    /// </summary>
    public string DebugCameraSize()
    {
        return "Camera Width: " + cameraWidth + ", CameraHeight: " + cameraHeight; 
    }



    /** ===== Debug Camera Aspect ===== **/
    /** =============================== **/

    /// <summary>
    /// ...
    /// </summary>
    public string DebugCameraAspect()
    {
        return "Camera Aspect: " + cameraAspect;
    }
}
}