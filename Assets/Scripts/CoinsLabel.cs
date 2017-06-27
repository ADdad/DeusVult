using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsLabel : MonoBehaviour {

	public UILabel coinsL;
	// Use this for initialization
	void Start () {
		string str = PlayerPrefs.GetString ("stats", null);
		LevelStat ls = JsonUtility.FromJson<LevelStat>(str);
		if(ls==null)coinsL.text="0000";
		else {
			string coins = (ls.coins+ls.coins2).ToString();
			int cLength = coins.Length;
		for(int i=0;i<4-cLength; i++){
			coins="0"+coins;
		}
		coinsL.text = coins;}
	}
	

}
