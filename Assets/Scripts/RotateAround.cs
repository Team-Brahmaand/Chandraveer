using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	public Transform target; 
	public int speed; 
	
	void Start() {
		if (target == null) 
		{
			target = this.gameObject.transform;
			Debug.Log ("RotateAround target not specified. Defaulting to parent GameObject");
		}
	}

	
	void Update () {
		
		transform.RotateAround(target.transform.position,target.transform.up,speed * Time.deltaTime);
	}
}
