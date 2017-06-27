using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController current;
	Vector3 startingPosition;
	public int Level = 0;
	void Awake() {
		current = this;
	}


	public void setStartPosition(Vector3 pos){
		this.startingPosition = pos;
	}

	public void onKnightDeath(HeroKnight kng){
		//kng.orcAttack();
		kng.transform.position = this.startingPosition;
		
	}

	public void onRabbitDeath(HeroRabbit kng){
		kng.transform.position = this.startingPosition;
		//hb.die();
	}
}
