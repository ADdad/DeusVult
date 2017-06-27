using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour {

	public MyButton playButton;
	public Sprite oned;
	public Sprite off;

	void Start () {
		playButton.signalOnClick.AddListener(this.onPlay);
		if(SoundManager.Instance.isSoundOn())this.GetComponent<UI2DSprite>().sprite2D = oned;
		else this.GetComponent<UI2DSprite>().sprite2D = off;
	}
	void onPlay() {
		SoundManager.Instance.setSoundOn(!SoundManager.Instance.isSoundOn());
		if(SoundManager.Instance.isSoundOn())this.GetComponent<UI2DSprite>().sprite2D = oned;
		else this.GetComponent<UI2DSprite>().sprite2D = off;
	}
}
