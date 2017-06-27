using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelDoor : MonoBehaviour {

void OnTriggerEnter2D(Collider2D collider){
	HeroKnight rabit = collider.GetComponent<HeroKnight>();

		if(rabit != null){
			PlayerPrefs.SetInt("damage", rabit.dmg);
			int t = PlayerPrefs.GetInt("lvl", 0);
			t++;
			PlayerPrefs.SetInt("lvl", t);
			SceneManager.LoadScene ("ChooseLevelScene");
			}
		
}
}

