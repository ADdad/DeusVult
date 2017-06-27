using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	public MyButton menuButton;
	

	void Start () {
		menuButton.signalOnClick.AddListener(this.onClose);
	}
	void onClose() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
