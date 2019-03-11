using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class gameMaster3 : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;

	private int ok = 1;
	private string teksti;
	public static Sprite kortti;

	public static bool aloitaSekoitus = false;
	public Vector2 koordinaatti = new Vector2 ();

	public static List<GameObject> kuvaLista = new List<GameObject> ();
	public static List<Sprite> spriteLista = new List<Sprite> ();
	public static List<Sprite> spriteLista2 = new List<Sprite> ();

	void Awake ()
	{
		kortti = Resources.Load ("kortti", typeof(Sprite)) as Sprite;

		for (int i = 0; i < 10; i++) {
			teksti = "A" + ok;
			sprite1 = Resources.Load (teksti, typeof(Sprite)) as Sprite;
			spriteLista.Add (sprite1);
			ok += 1;
		}
		aloitaSekoitus = true;
		SpriteScriptMuistiPeli.odota = true;
	}

	// Use this for initialization
	void Start () {
		if (aloitaSekoitus == true) {
			Sekoita ();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Sekoita()
	{
		Debug.Log ("Sekoittuu");
		int randomi1 = 0;
		int luku = 0;

		for (int i = 0; i < 19; i++) 
		{

			do 
			{
				luku = Random.Range (0, kuvaLista.Count);
				randomi1 = Random.Range (0, kuvaLista.Count);

			} while (luku == randomi1);


			koordinaatti = kuvaLista[luku].gameObject.transform.position;		//koordinaatti on tyhjä Vector2
			kuvaLista[luku].gameObject.transform.position = kuvaLista[randomi1].gameObject.transform.position;
			kuvaLista[randomi1].gameObject.transform.position = koordinaatti;

		}

		Debug.Log ("Sekoitettu");
		SpriteScriptMuistiPeli.odota = false;
	}
}
