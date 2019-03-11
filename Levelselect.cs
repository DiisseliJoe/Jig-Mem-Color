using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Levelselect : MonoBehaviour {


	public static int whichlevel;
	public static string levelNumber;
	public static string language = "";
	public static int whichColoring;
	public static string coloringNumber;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	//Kaikki scenejen välissä liikkumis napit ja toiminnot
	{
		if (gameObject.name == "Muistipeli") {
			SceneManager.LoadScene ("MemoryGame");
		}
		//Gamemode ohjaa mitä kuvia scripti asettaa peli valikkoon
		if (gameObject.name == "Varityspeli") {
			AddingLevels.GameMode = "Color";
			AddingLevels.Generatedlevelselection = false;
			SceneManager.LoadScene ("mainpuzlemenutest");
		}
		if (gameObject.name == "Palapeli") 
		{
			AddingLevels.GameMode = "Jigsaw";
			AddingLevels.Generatedlevelselection = false;
			SceneManager.LoadScene ("mainpuzlemenutest");
		}
		//käy läpi mitä kuvaa on painettu ja kumpaan peliin viedään
		if (gameObject.tag == "LevelTag") {
			int i = 0;
			do {
				i++;
				levelNumber = "Level" + i;
			} while (gameObject.name != levelNumber);
			if (gameObject.name == levelNumber) {
				whichlevel = i;
				if (AddingLevels.GameMode == "Jigsaw") {
					SceneManager.LoadScene ("Palapeli");
				}
				if (AddingLevels.GameMode == "Color") {
					SceneManager.LoadScene ("ColoringBook");
				}
			}
		}

		if (gameObject.name == "ReturntoLevelSelect") {
			SceneManager.LoadScene ("mainpuzlemenutest");
		}
		//Muisti pelin poistumis nuoli. Clearaa kaikki listat.
		if (gameObject.name == "BacknuoliMuisti") {
			if (SpriteScriptMuistiPeli.odota == false) 
			{
				MuistiPeliCanvas.EndGame = true;
				gameMaster3.spriteLista.Clear ();
				gameMaster3.kuvaLista.Clear ();
				SceneManager.LoadScene ("GameMainMenu");
			}
		}
		if (gameObject.name == "Backnuoli") {
				MovepieceVerInv.Listed = false;
				MovepieceVerInv.pieceList.Clear ();
				AddingLevels.LevelList.Clear ();
				SceneManager.LoadScene ("GameMainMenu");
		}
		if (gameObject.name == "BacknuoliToMenu") {
			MovepieceVerInv.Listed = false;
			MovepieceVerInv.pieceList.Clear ();
			AddingLevels.LevelList.Clear ();
			AddingLevels.Generatedlevelselection = false;
			SceneManager.LoadScene ("mainpuzlemenutest");
		}
		//kolme alla olevaa ovat Väritys pelin poistumis napit
		if (gameObject.name == "BacknuoliColor") {
			CanvasScript.Quit = true;
		}
		if (gameObject.name == "Kyllä") {
			CanvasScript.Yes = true;
			CanvasScript.Quit = false;
			CanvasScript.Once = false;
			AddingLevels.LevelList.Clear ();
			AddingLevels.Generatedlevelselection = false;
			SceneManager.LoadScene("mainpuzlemenutest");
		}
		//peli jatkuu
		if (gameObject.name == "Ei") {
			CanvasScript.Yes = true;
			CanvasScript.Quit = false;
			CanvasScript.Once = false;
		}
			


	}
}
