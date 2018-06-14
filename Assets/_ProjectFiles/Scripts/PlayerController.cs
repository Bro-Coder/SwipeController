using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public GameObject currentBoundary;
	Rigidbody rb;
	public bool check = false;
	public float speed;
	public Text SpeedDebugText;
	int i =0;
	private bool dragging = false;
	Vector3 worldStartPoint;
	Camera cam;
	public float speedMovementX;
	void Awake ()
	{
		cam = Camera.main;
		speedMovementX = 5f;

	}

	void Start () {
		rb = transform.GetComponent<Rigidbody> ();
		Input.multiTouchEnabled = false;
		SpeedDebugText.text = speedMovementX.ToString ();
	}



	void Update()
	{
		transform.position += Vector3.forward * speed * Time.deltaTime;

		if (speed <= 40f)
		{
			speed += Time.deltaTime;
//			Debug.Log ("Speed player = "+speed);
		}

		StartCoroutine (SwipePlayer());
	}

		
	IEnumerator SwipePlayer()
	{
		if (Input.touchCount == 1) 
		{
			Touch currentTouch = Input.GetTouch (0);

			if (currentTouch.phase == TouchPhase.Began) {
				worldStartPoint = cam.ScreenToWorldPoint (new Vector3(currentTouch.position.x, currentTouch.position.y, 1f));
				//	FinalText.text = "B" + worldStartPoint.x.ToString();
			} 
			else if (currentTouch.phase == TouchPhase.Moved) {
				Vector3 temp = cam.ScreenToWorldPoint (new Vector3(currentTouch.position.x, currentTouch.position.y, 1f));
				float worldDelta = temp.x - worldStartPoint.x;

				this.transform.Translate (worldDelta * speedMovementX , 0, 0);
				var pos =  Mathf.Clamp(this.transform.position.x, -1.3f, 1.3f);
				this.transform.position = new Vector3 (pos, transform.position.y, transform.position.z);
				worldStartPoint = temp;
			}
		}
		yield return null;
	}

	public void EnhanceSpeed()
	{
		speedMovementX += 1f;
		SpeedDebugText.text = speedMovementX.ToString ();
	}

	public void DegradeSpeed()
	{
		speedMovementX -= 1f;
		SpeedDebugText.text = speedMovementX.ToString ();
	}

	public void Reset()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}
}


