using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {
	public GameObject QuitScreen;
	public CanvasGroup QuitTexts;
	public static bool Yes = false;
	public static bool Quit = false;
	public static bool Once = false;
	// Use this for initialization
	void Start () {
		QuitTexts = GetComponent<CanvasGroup> ();
		QuitTexts.alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//näyttää varmistus teksitin poistumista varten
		if (Quit == true) {
			if (Once == false) {
				Once = true;
				QuitScreen.transform.position = new Vector2 (0f, 0f);
				QuitTexts.alpha = 1;
			}
		}
		if (Yes == true) {
			Yes = false;
			QuitTexts.alpha = 0;
			QuitScreen.transform.position = new Vector2 (850, 0);
		}
	
	}
}
