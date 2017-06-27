using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {


	public string sceneName = "Level1";
	public int lvl = 0;
	bool let_get = false;

void Start(){
	string str = PlayerPrefs.GetString ("stats", null);
	LevelStat ls = JsonUtility.FromJson<LevelStat>(str);
	if(sceneName=="Level1"){
		let_get=true;
	}
	if(ls!=null){
		if(sceneName=="Level2" && ls.level1){
			Destroy(this.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>());
			let_get=true;
		}
	}
}

void OnTriggerEnter2D(Collider2D collider){
	HeroRabbit rabit = collider.GetComponent<HeroRabbit>();

		if(rabit != null && let_get){
			SceneManager.LoadScene (sceneName);
		}
		
}
}