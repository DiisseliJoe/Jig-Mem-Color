using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageColor : MonoBehaviour {
	public GameObject Kyllatext;
	public GameObject Eitext;
	public GameObject Quittext;
	// Use this for initialization
	void Start () {
		LanguageSelect.Active =  true;
	}
	
	// Update is called once per frame
	void Update () {
		if (LanguageSelect.Active == true) {
			ChangingLanguage ();
		}
	}
	void ChangingLanguage()
	{
		Debug.Log (Levelselect.language);
		if (Levelselect.language == "Fin") {
			Kyllatext.GetComponent<Text> ().text = "KYLLÄ";
			Eitext.GetComponent<Text> ().text = "   EI";
			Quittext.GetComponent<Text> ().text = "POISTU PELISTÄ?";
		}
		if (Levelselect.language == "Eng") {
			Kyllatext.GetComponent<Text> ().text = " YES";
			Eitext.GetComponent<Text> ().text = "  NO";
			Quittext.GetComponent<Text> ().text = "   QUIT GAME?";
		}
		if (Levelselect.language == "Swe") {
			Kyllatext.GetComponent<Text> ().text = "   JA";
			Eitext.GetComponent<Text> ().text = "  NEJ";
			Quittext.GetComponent<Text> ().text = " AVTRÄDA SPEL?";
		}
		LanguageSelect.Active = false;
	}
}
