using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHere : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		HeroKnight knight = collider.GetComponent<HeroKnight>();

		if(knight != null){
			LevelController.current.onKnightDeath(knight);
		}
	}
}
