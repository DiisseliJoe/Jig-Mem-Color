using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public static int remainingPieces = 12;
	public static int listObjects;
	public static bool Shuffled = false;
	public static bool PlacedOne = false;

	public static int x;
	public static int y;
	public static int a;

	public static string b = "";
	public static string Piecetag = "PieceTag";
	public static string Sockettag = "SocketTag";
	public static string checkplacementy = "y";

	public GameObject Pieces;
	public GameObject Sockets;

	public GameObject Piece;
	public GameObject Socket;

	private Vector3 First;
	private Vector3 Second;
	private Vector3 Third;

	// Use this for initialization
	void Awake()
	{
		remainingPieces = 12;
	}
	void Start () {
			randomStartPosition();
			PlaceOne ();
	}
	// Update is called once per frame
	void Update () {
			if (remainingPieces <= 0) 
			{
				StartCoroutine(Finished());
		}
	}
	IEnumerator Finished()
	{
		yield return new WaitForSecondsRealtime(2);
		victoryScreen();
	}
	void victoryScreen()
	{
		Shuffled = false;
		MovepieceVerInv.Listed = false;
		MovepieceVerInv.pieceList.Clear ();
		SceneManager.LoadScene ("LevelComplete");
	}
	void randomStartPosition()
	{
		for (int i = 0; i < 15; i++) {
			do {
				x = Random.Range (0, MovepieceVerInv.pieceList.Count);
				y = Random.Range (0, MovepieceVerInv.pieceList.Count);
			} while(x == y);

			Second = MovepieceVerInv.pieceList[x].gameObject.transform.position;
			MovepieceVerInv.pieceList[x].gameObject.transform.position = MovepieceVerInv.pieceList[y].gameObject.transform.position;
			MovepieceVerInv.pieceList[y].gameObject.transform.position = Second;
		}
		Shuffled = true;
		PlacedOne = false;
	}
	void PlaceOne(){
		
		a = Random.Range (1, MovepieceVerInv.pieceList.Count);
		b = "A" + a;
		Sockets = GameObject.Find ("Sockets");
		if (Sockets != null) {
			Socket = Sockets.transform.Find (b).gameObject;
			Third = Socket.transform.position;
		}

		Pieces = GameObject.Find ("Pieces");
		if (Pieces != null) {
			Piece = Pieces.transform.Find (b).gameObject;
			Piece.transform.position = Third;
			PlacedOne = true;
		}


	}
}
