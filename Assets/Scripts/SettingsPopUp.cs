using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopUp : MyButton {

	public MyButton blackBackground;
	public MyButton closing;
	

	void Start () {
		closing.signalOnClick.AddListener(this.onClose);
		blackBackground.signalOnClick.AddListener(this.onClose);
	}
	void onClose() {
		NGUITools.Destroy(this.transform.gameObject);
	}
}
