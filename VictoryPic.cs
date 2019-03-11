using UnityEngine;
using System.Collections;

public class VictoryPic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		VictoryScreenpic ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void VictoryScreenpic(){
		string Kuvaname="kuva" + Levelselect.whichlevel;

		GetComponent<SpriteRenderer> ().sprite = Resources.Load (Kuvaname, typeof(Sprite)) as Sprite;
		transform.localScale = new Vector2 (0.5f, 0.5f);
	}
}
