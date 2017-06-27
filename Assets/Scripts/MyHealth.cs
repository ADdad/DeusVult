using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHealth : MonoBehaviour {

	public UILabel Health_Label;
	public float Health_f = 1f;
	
	// Update is called once per frame
	void Update () {
		float UpdateHealth_f = Health_f*100;
		if(UpdateHealth_f >=0f && (UpdateHealth_f <=100f))
		{
			GameObject.Find("HealthBar").GetComponent<UIProgressBar>().value = Health_f;
			Health_Label.text = (UpdateHealth_f.ToString() + "% Health");
		}
		else if(UpdateHealth_f>100)Health_f=1f;
	}
}
