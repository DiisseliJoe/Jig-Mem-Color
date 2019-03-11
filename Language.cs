using UnityEngine;
using System.Collections;

public class Language : MonoBehaviour {
	public GameObject Memorygaem;
	public GameObject Colorgaem;
	public GameObject Jigsawgaem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (LanguageSelect.Active == true) {
			ChangingLanguage ();
		}

	}
	void ChangingLanguage ()
	{
		if (Levelselect.language == "Fin") {
				Jigsawgaem.GetComponent<TextMesh> ().text = "\tPalapeli";
				Colorgaem.GetComponent<TextMesh> ().text = "  Värityskirja";
				Memorygaem.GetComponent<TextMesh> ().text = "   Muistipeli";
		}
		if (Levelselect.language == "Eng") {
				Jigsawgaem.GetComponent<TextMesh> ().text = "Jigsaw Puzzle";
				Colorgaem.GetComponent<TextMesh> ().text = "Coloring Book";
				Memorygaem.GetComponent<TextMesh> ().text = "Memory Game";
		}
		if (Levelselect.language == "Swe") {
				Jigsawgaem.GetComponent<TextMesh> ().text = "     Läggspel";
				Colorgaem.GetComponent<TextMesh> ().text = "    Målarbok";
				Memorygaem.GetComponent<TextMesh> ().text = "   Minnesspel";
		}
		LanguageSelect.Active = false;
	}
}
