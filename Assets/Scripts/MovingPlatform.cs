using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Vector3 MoveBy;

	public float speed = 1;
	public float pause = 2;

	Vector3 pointA;
	Vector3 pointB;

	bool going_to_a = false;

	bool stop = true;
	float time_to_wait = 0;
	float coef = 1; //factor to direct moving
	
	void Start () {
		this.pointA = this.transform.position;
		this.pointB = this.pointA + MoveBy;
		if(MoveBy.y!=0)coef = Mathf.Abs(MoveBy.x/MoveBy.y);
	}

	public void StartMove(){
		stop = false;
	}
	
	
	void Update () {
		
	}

	
	void FixedUpdate() {
		if(time_to_wait>0 || stop){
			time_to_wait-=Time.deltaTime;
			return;
		}
		Vector3 my_pos = this.transform.position;
		Vector3 target;

		if(going_to_a) {
			target = this.pointA;
		}
		else target = this.pointB;

		Vector3 destination = target - my_pos;
		destination.z = 0;
		destination = destination.normalized;

		if(isArrived(my_pos,target)){
			time_to_wait = pause;
			going_to_a=!going_to_a;
		}
		else{
			my_pos.x+=speed*Time.deltaTime*coef*destination.x;
			my_pos.y+=speed*Time.deltaTime*destination.y;
		}
		this.transform.position=my_pos;
	}

	bool isArrived(Vector3 pos, Vector3 target) {
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance(pos, target) < 0.2f;	
	}
}
