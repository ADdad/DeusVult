using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollow : MonoBehaviour {

	public HeroKnight kng;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform kng_transform = kng.transform;

		Transform camera_transform = this.transform;

		Vector3 kng_position = kng_transform.position;
		Vector3 camera_position = camera_transform.position;

		camera_position.x = kng_position.x;
		camera_position.y = kng_position.y;

		camera_transform.position = camera_position;
	}
}
