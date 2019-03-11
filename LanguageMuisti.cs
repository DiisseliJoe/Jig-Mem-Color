using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageMuisti : MonoBehaviour {
	public GameObject Teksti;
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
			Teksti.GetComponent<Text> ().text = "   HIENOA TYÖTÄ!";
		}
		if (Levelselect.language == "Eng") {
			Teksti.GetComponent<Text> ().text = "   GREAT WORK!";
		}
		if (Levelselect.language == "Swe") {
			Teksti.GetComponent<Text> ().text = "  FÄRDIGSTÄLLD!";
		}
		LanguageSelect.Active = false;
	}
}
