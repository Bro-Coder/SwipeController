using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public static CameraController instance;

	public Transform target;
	void Awake()
	{
		instance = this;	
	}
	
	void LateUpdate()
	{
		if (target != null) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, target.position.z - 5f);
		}		
	}
}
