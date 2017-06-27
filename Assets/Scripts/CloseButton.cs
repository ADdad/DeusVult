using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour {

	public MyButton closeButton;
	

	void Start () {
		closeButton.signalOnClick.AddListener(this.onClose);
	}
	void onClose() {
	}
}
