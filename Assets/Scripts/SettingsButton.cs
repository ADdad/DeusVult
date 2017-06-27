using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour {

	public MyButton settingsButton;
	public GameObject settingsPrefab;
	
	void Start () {
		settingsButton.signalOnClick.AddListener(this.showSettings);
	}

	void showSettings() {

	GameObject parent = UICamera.first.transform.parent.gameObject;

	GameObject obj = NGUITools.AddChild(parent, settingsPrefab);

}
	

	
	
}
