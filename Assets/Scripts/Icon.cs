using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour {
public static int id = 0;
void Awake(){
			id++;
			int t = PlayerPrefs.GetInt("lvl", 0);
			if(t>=id)GetComponent<UI2DSprite>().color = Color.white;
}
}
