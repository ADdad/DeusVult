using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completing : MonoBehaviour {

	public enum Check {
		Fruits,
		Crystals,
		Completing
	}


	public Check chk = Check.Completing;

	public Sprite galochka;
	public int levelNum = 0;
	// Use this for initialization
	void Start () {
		string str = PlayerPrefs.GetString ("stats", null);
		LevelStat ls = JsonUtility.FromJson<LevelStat>(str);
		if(ls!=null){
		if(chk==Check.Completing){
		if(ls.level1 && levelNum==1)this.GetComponent<SpriteRenderer>().sprite = galochka;
		if(ls.level2 && levelNum==2)this.GetComponent<SpriteRenderer>().sprite = galochka;
	}
	if(chk==Check.Fruits){
		if(ls.allFruits1 && levelNum==1)this.GetComponent<SpriteRenderer>().sprite = galochka;
		if(ls.allFruits2 && levelNum==2)this.GetComponent<SpriteRenderer>().sprite = galochka;
	}
	if(chk==Check.Crystals){
		if(ls.all_crystal[0] && levelNum==1)this.GetComponent<SpriteRenderer>().sprite = galochka;
		if(ls.all_crystal[1] && levelNum==2)this.GetComponent<SpriteRenderer>().sprite = galochka;
	}
	}
	}
	
	
}
