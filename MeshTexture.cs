using UnityEngine;
using System.Collections;

public class MeshTexture : MonoBehaviour {
	
	public Material baseMaterial;
	public RenderTexture CanvasTexture;
	public static int BrushCounter = 0;
	public static bool Clear = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (BrushCounter > 20) {
			MergeTexture ();
		}*/
	
	}
	void MergeTexture ()
	{
		RenderTexture.active = CanvasTexture;
		int widht = CanvasTexture.width;
		int height = CanvasTexture.height;
		Texture2D tex = new Texture2D (widht, height, TextureFormat.RGB24, false);
		tex.ReadPixels (new Rect (0, 0, widht, height), 0, 0);
		tex.Apply ();
		RenderTexture.active = null;
		baseMaterial.mainTexture = tex;
		Clear = true;
		BrushCounter = 0;
	}
}
