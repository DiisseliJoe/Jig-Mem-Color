using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddingLevels : MonoBehaviour {

	public static string GameMode = "";
	public GameObject Level1;
	public GameObject Level2;
	public GameObject Level3;
	public GameObject Level4;
	public GameObject Level5;
	public GameObject Level6;
	public GameObject Level7;
	public GameObject Level8;
	public GameObject Level9;
	public GameObject Level10;
	public GameObject Level11;
	public GameObject Level12;
	public GameObject Level13;
	public GameObject Level14;
	public GameObject Level15;
	public GameObject Level16;

	private GameObject Levels; 

	public GameObject FourthBlock;
	public GameObject ThirdBlock;
	public GameObject SecondBlock;

	public static Sprite LevelPic;

	public static bool Generatedlevelselection = false;

	public static List<GameObject> LevelList = new List<GameObject> ();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Generatedlevelselection == false) {
			AddToList ();
			AddLevels ();
			Generatedlevelselection = true;
		}
	}
	void AddLevels(){
		//lisää level objecteihin kuvan gamemoden perusteella.
		int a = 0;
			foreach (GameObject Level in LevelList) {
			string Kuvaname = "default";
			if (AddingLevels.GameMode == "Jigsaw") {
				Kuvaname = "kuva" + (a + 1);
			}
			if (AddingLevels.GameMode == "Color") {
				Kuvaname = "Varitys" + (a + 1);
			}
				LevelPic = Resources.Load (Kuvaname, typeof(Sprite)) as Sprite;
				AttachPic (Level);

			if (Level.name == Level13.name) {
				if (LevelPic == null) {
					Destroy (FourthBlock);
				}
			}
			if (Level.name == Level9.name) {
				if (LevelPic == null) {
					Destroy (ThirdBlock);
				}
			}
			if (Level.name == Level5.name) {
				if (LevelPic == null) {
					Destroy (SecondBlock);
				}
			}
			if (LevelPic == null) {
				Destroy (Level);
			}
				a++;
		}
	}
	void AddToList(){
		for (int i = 0; i < 16; ) {
			string levelName = "Level"+(i+1);
			Levels = GameObject.Find (levelName);
			if (Levels.name == levelName) {
				LevelList.Add (Levels);
				}
			i++;

		}
	}
	void AttachPic(GameObject Level){
		Level.AddComponent<BoxCollider2D> ();
		Level.GetComponent<BoxCollider2D> ().size = new Vector2 (21f,17f);

		Level.GetComponent<SpriteRenderer> ().sprite = LevelPic;
		Level.transform.localScale = new Vector2 (0.31f, 0.235f);


		}
	}
