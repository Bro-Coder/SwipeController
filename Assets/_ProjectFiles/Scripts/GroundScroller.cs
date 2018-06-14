using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour {

	public static GroundScroller instance;

	[SerializeField]
	private List<GameObject> segments, targetPoints;
	[SerializeField]
	private List<Vector3> segmentPosition;
	[SerializeField]
	public Transform player;
	public int currentSegment, firstSegment;
	private Vector3 position;
	void Start()
	{
		instance = this;
		currentSegment = 2;
		firstSegment = 0;
		for (int i = 0; i < 27; i++) {
			segmentPosition.Add (segments[i].transform.position);
		}

	}

	void Update()
	{
		if (player!=null && player.position.z > targetPoints [currentSegment].transform.position.z) {
			UpdateSegments ();
		}
	}

	public IEnumerator ResetSegments()
	{
		currentSegment = 2;
		firstSegment = 0;
		for (int i = 0; i < 27; i++) {
			segments [i].transform.position = segmentPosition [i];
		}
		Debug.Log ("Segments Reset");
		yield return null;
	}


	void UpdateSegments()
	{
		position = new Vector3 (segments [firstSegment].transform.position.x, segments [firstSegment].transform.position.y, segments [firstSegment].transform.position.z + 270f);
		int x = segments [firstSegment].transform.GetChildCount ();
		segments [firstSegment].transform.position = position;
		if (currentSegment < segments.Count-1) {
			currentSegment++;
		}
		else 
		{
			currentSegment = 0;
		}
		if (firstSegment < segments.Count-1) {
			firstSegment++;
		}
		else 
		{
			firstSegment = 0;
		}
	}

}
