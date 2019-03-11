using UnityEngine;
using System.Collections;

public class ColorPicture : MonoBehaviour {
	public static string ColorPicName = "";
	public Sprite ColorPic;

	// Use this for initialization
	void Start () {
		ColorPicName = "Color" + Levelselect.whichlevel;
		ColorPic = Resources.Load (ColorPicName, typeof(Sprite)) as Sprite;
		GetComponent<SpriteRenderer> ().sprite = ColorPic;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
