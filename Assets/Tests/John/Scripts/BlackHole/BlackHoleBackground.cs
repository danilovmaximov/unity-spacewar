using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlackHoleBackground : MonoBehaviour
{
	public Camera BlackHoleCamera;
	private MeshRenderer BlackHoleMeshRenderer;
	private Material BlackHoleMaterial;
	private RenderTexture BlackHoleRenderTexture;

    void Awake()
    {
        BlackHoleMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        BlackHoleRenderTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);

        // Setting this new generated texture as target texture
    	BlackHoleCamera.targetTexture = BlackHoleRenderTexture;

        // Creating new material and setting it up with shader and render texture
        BlackHoleMaterial = new Material(Shader.Find("Standard"));
        BlackHoleMeshRenderer.materials[0] = BlackHoleMaterial;
        BlackHoleMeshRenderer.materials[0].mainTexture = BlackHoleRenderTexture;
        BlackHoleMeshRenderer.materials[0].shader = Shader.Find("Unlit/Texture");
    }

    void Update()
    {

        if(Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position += new Vector3(0.0f, 0.1f, 0.0f);
        } else if(Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position -= new Vector3(0.0f, 0.1f, 0.0f);
        }
    	if(Input.GetKey(KeyCode.LeftArrow))
    	{
            gameObject.transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
    	}
    	else if(Input.GetKey(KeyCode.RightArrow))
    	{
            gameObject.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
    	}
        if(Input.GetKey(KeyCode.W))
        {
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.0f);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.0f);
        }
        if(Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0, 0, -5.0f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0, 0, 5.0f);
        }

        // Can you use Vector2 for it?... or by vector multiplication?..
    	BlackHoleCamera.transform.position = new Vector3(
    		gameObject.transform.position.x,
    		gameObject.transform.position.y, -20.0f);

        // I don't know why I wrote it...
        BlackHoleCamera.transform.rotation = Quaternion.Euler(
            0.0f,
            0.0f,
            gameObject.transform.rotation.z);
        BlackHoleCamera.orthographicSize = gameObject.transform.localScale.x;
    }
}
