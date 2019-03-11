using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaintGM : MonoBehaviour {
	/*
http://codeartist.mx/tutorials/dynamic-texture-painting/

mahdollinen ratkuisu tyyli linkin takana.
Lyhyesti piirtäessä instantiatetaan eri brusheja ja joka 1000(suotavasti pienempi) kaikki mitä on piirretty mergetään textureen josta
tehdään uusi pohja.
Tämän jälkeen kaikki brushit mitä on piirretty poistetaan mutta koska ne on mergetty ja niistä tehtiin texture kuva näytää vielläkin samalta mutta nyt
siellä ei ole enää 1000 brushia hidastamassa peliä.
R.I.P
	*/

	public Transform BrushContainer;
	public Transform BaseDot;
	public Transform BaseSpray;
	public Transform BaseFade;
	public KeyCode MouseLeft;
	public static string toolType = "brush";
	public static Color currentColor;
	public static int currentOrder;
	public static float currentScale = 1f;
	public static float MaxScale = 5f;
	public static float MinScale = 0.1f;


	// Use this for initialization
	void Start () {
		toolType = "brush";

	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Vector2 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		if (toolType == "brush") {
			if (Input.GetKey (MouseLeft)) {
				(Instantiate (BaseDot, objPosition, BaseDot.rotation) as Transform).transform.parent = BrushContainer.transform;
				MeshTexture.BrushCounter += 1;
			}
		}
		if (toolType == "eraser") {
			//piirtää valkoista
			if (Input.GetKey (MouseLeft)) {
				currentColor = new Color (100, 100, 100);
				(Instantiate (BaseDot, objPosition, BaseDot.rotation) as Transform).transform.parent = BrushContainer.transform;
				MeshTexture.BrushCounter += 1;
			}
		}
		if (toolType == "spray") {
			//piirtää spray kuviota
			if (Input.GetKey (MouseLeft)) {
				(Instantiate (BaseSpray, objPosition, BaseSpray.rotation) as Transform).transform.parent = BrushContainer.transform;
				MeshTexture.BrushCounter += 1;
			}
		}
		if (toolType == "fade") {
			//piirtää hälvenevää ympyrää
			if (Input.GetKey (MouseLeft)) {
				(Instantiate (BaseFade, objPosition, BaseFade.rotation) as Transform).transform.parent = BrushContainer.transform;
				MeshTexture.BrushCounter += 1;
			}
		}
		/*
		if (MeshTexture.Clear == true) {
			foreach (Transform child in BrushContainer.transform) {
				Destroy (child.gameObject);
			}
			MeshTexture.Clear = false;
		}*/

	}
}
