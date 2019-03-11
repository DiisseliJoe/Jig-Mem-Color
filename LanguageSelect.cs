using UnityEngine;
using System.Collections;

public class LanguageSelect : MonoBehaviour {
	public static bool finnish = false;
	public static bool swedish = false;
	public static bool english = false;

	public static bool Active = false;
	// Use this for initialization
	void Start () {
		if (VictoryScreentext.FirstTime == false) {
			finnish = true;
			swedish = false;
			english = false;
			Levelselect.language = "Fin";
			Active = true;
			VictoryScreentext.FirstTime = true;
		}
		if (Levelselect.language == "Fin") {
			Finnish ();
		}
		if (Levelselect.language == "Eng") {
			English ();
		}
		if (Levelselect.language == "Swe") {
			Swedish ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		if (gameObject.name == "Finnish") {
			Finnish ();
		}
		if (gameObject.name == "English") {
			English ();
		}
		if (gameObject.name == "Swedish") {
			Swedish ();
		}
	}
	void Finnish(){
		finnish = true;
		swedish = false;
		english = false;
		Levelselect.language = "Fin";
		Active = true;
	}
	void English(){
		finnish = false;
		swedish = false;
		english = true;
		Levelselect.language = "Eng";
		Active = true;
	}
	void Swedish(){
		finnish = false;
		swedish = true;
		english = false;
		Levelselect.language = "Swe";
		Active = true;
	}
}
