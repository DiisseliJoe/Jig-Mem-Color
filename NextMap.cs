using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextMap : MonoBehaviour {
	public GameObject BackArrow;
	// Use this for initialization
	void Start () {
		}
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		//siirtää kameraa punaisilla nuolilla seuraavan talon ja kenttien päälle
		if (gameObject.name == "Nextmap") {
			Camera.main.transform.position =  new Vector3 (Camera.main.transform.position.x + 20f, 0f, -10f);
			BackArrow.transform.position = new Vector2 (BackArrow.transform.position.x + 20f, -3.9f);
		}
		if (gameObject.name == "Previousmap") {
			Camera.main.transform.position =  new Vector3 (Camera.main.transform.position.x - 20f, 0f, -10f);
			BackArrow.transform.position = new Vector2 (BackArrow.transform.position.x - 20f, -3.9f);
		}
	}

}
