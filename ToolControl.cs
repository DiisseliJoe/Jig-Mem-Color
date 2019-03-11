using UnityEngine;
using System.Collections;

public class ToolControl : MonoBehaviour {
	public Color ActiveColor = new Color (0,255,0);
	public Color NotActiveColor = new Color (255,255,255);
	public static bool ScaleChange = false;
	public GameObject Brush;
	public GameObject Eraser;
	public GameObject Fade;
	public GameObject Spray;
	// Use this for initialization
	void Start () {
		if (gameObject == Brush) {
			PaintGM.toolType = "brush";
			Brush.GetComponent<SpriteRenderer> ().color = new Color(0, 100, 0);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ScaleChange == true) {
			if (PaintGM.currentScale > PaintGM.MaxScale) {
				PaintGM.currentScale = PaintGM.MaxScale; 
				ScaleChange = false;
			}
			if (PaintGM.currentScale < PaintGM.MinScale) {
				PaintGM.currentScale = PaintGM.MinScale;
				ScaleChange = false;
			}
		}
	}

	void OnMouseDown(){
		//Työkalujen kontrollit. muuttaa värit työkaluissa valkoisiksi ja aktivoidun vihreäksi .Muuttaa "tooltypen" jotta kyseinen työkalu toimii
		if (gameObject == Eraser) {
			PaintGM.toolType = "eraser";
			ColorChange ();
			Eraser.GetComponent<SpriteRenderer> ().color = ActiveColor;
		}
		if (gameObject.name == "Brush") {
			PaintGM.toolType = "brush";
			ColorChange ();
			Brush.GetComponent<SpriteRenderer> ().color = ActiveColor;
			}
		if (gameObject.name == "Fade") {
			PaintGM.toolType = "fade";
			ColorChange ();
			Fade.GetComponent<SpriteRenderer> ().color = ActiveColor;
		}
		if (gameObject.name == "Spray") {
			PaintGM.toolType = "spray";
			ColorChange ();
			Spray.GetComponent<SpriteRenderer> ().color = ActiveColor;
		}
		if (gameObject.name == "sizeUp") {
			PaintGM.currentScale += 0.25f;
			ScaleChange = true;
		}
		if (gameObject.name == "sizeDown") {
			PaintGM.currentScale -= 0.25f;
			ScaleChange = true;
		}
	}
	void ColorChange(){
		//muuttaa kaikki kuvakkeet valkoiseksi
		Eraser.GetComponent<SpriteRenderer> ().color = NotActiveColor;
		Brush.GetComponent<SpriteRenderer> ().color = NotActiveColor;
		Fade.GetComponent<SpriteRenderer> ().color = NotActiveColor;
		Spray.GetComponent<SpriteRenderer> ().color = NotActiveColor;
	}
}
