using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovepieceVerInv : MonoBehaviour {
	
	public string pieceStatus = "";
	public string checkPlacement = "n";

	private bool dragging = false;
	private bool IsColliding = false;
	private bool IsInPosition = false;

	public static bool StartingGame = false;
	public bool ReadForGame = false;
	public static bool Listed = false;


	public Transform edgeParticles;
	public KeyCode placePiece;
	public Vector3 StartPosition;
	public static List<GameObject> pieceList = new List<GameObject> ();

	private Vector3 place;
	private Collider2D Other;
	public string LevelPicture = "";

	public float minimumDragDistance = 1f; 
	private bool isTouching;
	private Vector3 touchPoint;	
	private static GameObject selectedObject;
	public GameObject NullSelected;

	private bool Touched = false;
	private bool NotTouched = true;
	private bool Placed = false;


	private RaycastHit2D hit;

	void Awake(){
		StartingGame = true;
		addPiece ();
		GameMaster.listObjects = pieceList.Count;
		Listed = true;
		StartPos ();
	}
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if ((GameMaster.Shuffled == true) && (ReadForGame == false) && (StartingGame == true)) {
			StartPos ();
			ScalePieces ();
			ReadForGame = true;
		}
		if (GameMaster.remainingPieces == 0) {
			ReadForGame = false;
			StartingGame = false;
		}
		if (GameMaster.PlacedOne == true) {
			PlacedOne ();
		}
	}
	void FixedUpdate () 
	{
			if (!isTouching) {
				if (Input.GetMouseButtonDown (0)) {
					if (NotTouched == true) 
					{
						isTouching = true;
					if (pieceStatus != "locked") {
						hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

						this.touchPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);

						if (hit != null && hit.collider != null) {
							if (hit.collider.gameObject.tag == "PieceTag") {
								
							
								selectedObject = hit.collider.gameObject;
								Touched = true;
					
								checkPlacement = "n";
								selectedObject.GetComponent<Renderer> ().sortingOrder = 10;
								selectedObject.transform.localScale = new Vector3 (1.25f, 1.04f, 0f);

								selectedObject.SendMessage ("OnTouched", hit, SendMessageOptions.DontRequireReceiver);

							}
						}
					}
					}
				}
		}

		if (Input.GetMouseButtonUp (0)) {
			this.isTouching = false;
			if (pieceStatus != "locked" && Touched == true) {
				if (gameObject.name == selectedObject.name) {
					checkPlacement = "y";
					if (checkPlacement == "y") {
						if (!IsInPosition || !IsColliding) {
							transform.position = StartPosition;
							transform.localScale = new Vector3 (1f, 0.832f, 0f);
							NotTouched = true;
							selectedObject = NullSelected;
						}
						if (IsInPosition && IsColliding) {
							Placement (Other);
						}
						Touched = false;
						GetComponent<Renderer> ().sortingOrder = -2;
					}
			
				}
			}
			if (selectedObject != null) {

				selectedObject.SendMessage ("OnDraggingStopped", null, SendMessageOptions.DontRequireReceiver);
			}
				
		}

		if (isTouching && selectedObject != NullSelected) {

			OnTouchHeld ();
		}
	}

		private void OnTouchHeld() {
		if (pieceStatus != "locked" && Touched == true && Placed == false && NotTouched == true) {
			
		
			Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 dragAmount = (currentMousePosition - touchPoint);
			Vector3 directionToCurrentMousePosition = currentMousePosition - selectedObject.transform.position;

			DragSummary dragSummary = new DragSummary ();
			dragSummary.position = currentMousePosition;
			dragSummary.amount = dragAmount;
			dragSummary.direction = directionToCurrentMousePosition;

			if (dragAmount.magnitude > minimumDragDistance) {
				selectedObject.SendMessage ("OnDrag", dragSummary, SendMessageOptions.DontRequireReceiver);
			}

			if (Mathf.Abs (dragAmount.x) > minimumDragDistance) {
				selectedObject.SendMessage ("OnHorizontalDrag", dragSummary, SendMessageOptions.DontRequireReceiver);
			}

			if (Mathf.Abs (dragAmount.y) > minimumDragDistance) {
				selectedObject.SendMessage ("OnVerticalDrag", dragSummary, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	void OnTriggerStay2D(Collider2D other){
		IsColliding = true;
		if (other.gameObject.name == gameObject.name) {
			IsInPosition = true;
			Other = other;
			place = other.transform.position;
		}
	}

	void Placement(Collider2D other){
		if ((other.gameObject.name == selectedObject.name) && (checkPlacement == "y")) {
			pieceStatus = "locked";
			transform.position = place;
			Instantiate (edgeParticles, other.gameObject.transform.position, edgeParticles.rotation);
			checkPlacement = "n";
			other.GetComponent<BoxCollider2D> ().enabled = false;
			selectedObject.GetComponent<BoxCollider2D> ().enabled = false;
			GameMaster.remainingPieces -= 1;
			Touched = false;
			NotTouched = false;
			Placed = true;
			selectedObject = NullSelected;

		}
	} 
	 void OnTriggerExit2D(Collider2D other){
		IsInPosition = false;
		IsColliding = false;
	}
	void ScalePieces(){
		transform.localScale = new Vector2(1f, 0.832f);
	}
	void addPiece (){
		pieceList.Add (gameObject);
	}
	void StartPos(){
		StartPosition = gameObject.transform.position;
	}
	void PlacedOne(){
	if (GameMaster.PlacedOne == true) {
			if (gameObject.name == GameMaster.b) {
				selectedObject = gameObject;
				checkPlacement = "y";

				if (IsInPosition && IsColliding) {
					transform.localScale = new Vector3 (1.25f, 1.04f, 0f);
					Placement (Other);
					GameMaster.PlacedOne = false;
				}
			}
		}
	}
}
