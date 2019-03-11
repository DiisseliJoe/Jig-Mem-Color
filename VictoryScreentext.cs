using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VictoryScreentext : MonoBehaviour {
	public static int randomtext = 0;
	public GameObject Levelcomplete;
	public static bool FirstTime = false;
	// Use this for initialization
	void Start () {
		LanguageSelect.Active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (LanguageSelect.Active == true) {
			ChangingLanguage ();
		}
	}
		void ChangingLanguage ()
		{
		randomtext = Random.Range (0, 3);
		
			if ((LanguageSelect.finnish == true) && (!LanguageSelect.swedish) && (!LanguageSelect.english)) {
			if (randomtext == 0) {
				GetComponent<TextMesh> ().text = "\tVALMIS!";
			}
			if (randomtext == 1) {
				GetComponent<TextMesh> ().text = "HIENOA TYÖTÄ!";
			}
			if (randomtext == 2) {
				GetComponent<TextMesh> ().text = "HYVIN TEHTY!";
			}
			}
			if ((LanguageSelect.english == true) && (!LanguageSelect.swedish) && (!LanguageSelect.finnish)) {
			if (randomtext == 0) {
				GetComponent<TextMesh> ().text = " FINISHED!";
			}
			if (randomtext == 1) {
				GetComponent<TextMesh> ().text = "GREAT WORK!";
			}
			if (randomtext == 2) {
				GetComponent<TextMesh> ().text = " NICE JOB!";
			}
			}
			if ((LanguageSelect.swedish == true) && (!LanguageSelect.english) && (!LanguageSelect.finnish)) {
			if (randomtext == 0) {
				GetComponent<TextMesh> ().text = "FÄRDIGSTÄLLD!";
			}
			if (randomtext == 1) {
				GetComponent<TextMesh> ().text = "  JÄTTEBRA!";
			}
			if (randomtext == 2) {
				GetComponent<TextMesh> ().text = "FANTASTISK!";
			}
			}
			LanguageSelect.Active = false;
		}
	}
