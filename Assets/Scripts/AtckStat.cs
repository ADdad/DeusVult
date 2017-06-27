using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtckStat : MonoBehaviour {

	public UILabel Dmg_Label;
	public float atck = 1;
	// Use this for initialization
	void Start () {
		int s = PlayerPrefs.GetInt("damage", 0);
		if(s==0)Dmg_Label.text = "1";
		else Dmg_Label.text = s.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		Dmg_Label.text = atck.ToString();
	}
}
