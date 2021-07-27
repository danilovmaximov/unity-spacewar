using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameManagerComponents
{
class DebugManager
{
    private GameObject DebugWindow;
    private Canvas DebugWindowCanvas;
    private Text DebugWindowCanvasText;

    private string DebugBuffer = "";

    private float TextOffset = 5.0f;

    /** ===== Initialize Debug Window ===== **/
    /** =================================== **/

    public void InitializeDebugWindow()
    {
        // Setting up DebugWindow GameObject
        DebugWindow = GameObject.Instantiate(Resources.Load("Prefabs/Debug/DebugWindow", typeof(GameObject))) as GameObject;
        DebugWindow.name = "DebugWindow";

        // Setting up DebugWindow Canvas Object
        DebugWindowCanvas = DebugWindow.transform.Find("Canvas").GetComponent<Canvas>();
        DebugWindowCanvas.worldCamera = Camera.main;

        // Setting up UI Text Object
        DebugWindowCanvasText = DebugWindowCanvas.transform.Find("Text").GetComponent<Text>();
        DebugWindowCanvasText.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height / 2.0f);
        DebugWindowCanvasText.rectTransform.anchoredPosition = new Vector2(0.0f + TextOffset, -Screen.height / 2.0f - TextOffset);

        // Setting up UI Text Properties
        DebugWindowCanvasText.color = new Color(255,255,255);
        DebugWindowCanvasText.fontSize = 16;
    }



    /** ===== Append Debug Buffer ===== **/
    /** =============================== **/

    public void AppendDebugBuffer(string debugInfo)
    {
        DebugBuffer += debugInfo;
        DebugBuffer += "\n";
    }



    /** ===== Update Debug Text ===== **/
    /** ============================= **/

    public void UpdateDebugText()
    {
        DebugWindowCanvasText.text = DebugBuffer;
        DebugBuffer = "";
    }
}
}