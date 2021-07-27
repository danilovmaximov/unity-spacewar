using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagerComponents
{
public class ScreenManager
{
    /** ===== Game Screen Properties ===== **/
    /** ================================== **/

    private int ScreenWidth;
    private int ScreenHeight;



    /** ===== Initialize Screen Properties ===== **/
    /** ======================================== **/

    /// <summary>
    /// ...
    /// </summary>
    public void InitializeScreenProperties()
    {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
    }



    /** ===== Screen Size Change Check ===== **/
    /** ==================================== **/

    /// <summary>
    /// Changing the buffer screen size
    /// if current screen size changed.
    /// </summary>
    ///
    /// <todo>
    /// Make debugging tool, so we could
    /// see, how screen size have changed.
    /// </todo>
    public bool ScreenSizeChangeCheck()
    {
        if(ScreenWidth != Screen.width ||
           ScreenHeight != Screen.height)
        {
            ScreenWidth = Screen.width;
            ScreenHeight = Screen.height;
            return true;
        }

        return false;
    }



    /** ===== Debug Screen Size ===== **/
    /** ============================= **/

    /// <summary>
    /// ...
    /// </summary>
    public string DebugScreenSize()
    {
        return "Screen Width: " + ScreenWidth + ", Screen Height: " + ScreenHeight;
    }
}
}
