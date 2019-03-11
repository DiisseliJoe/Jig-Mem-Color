using UnityEngine;
using System.Collections;

public class ColorPicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		PaintGM.currentColor = GetComponent<SpriteRenderer> ().color;
		PaintGM.currentOrder += 1;
	}
}
