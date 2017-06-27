using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenPopUp : MyButton {

	public MyButton blackBackground;
	public MyButton closing;
	
	int coins, fruits, full;

	UILabel coinsLabel;
	UILabel fruitsLabel;
	CrystalBar cb, cb1;
	
	void Start () {
		/*closing.signalOnClick.AddListener(this.onClose);
		blackBackground.signalOnClick.AddListener(this.onClose);
		coinsLabel = this.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<UILabel>();
		fruitsLabel = this.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<UILabel>();
		cb = this.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.GetComponent<CrystalBar>();
		cb1 = (CrystalBar)LevelController.current.cb;
		cb.loadSprites(cb1.red, cb1.green, cb1.blue);
		
		for(int i =0; i<3; i++){
			if(cb1.colir[i]!=-1)cb.add(cb1.colir[i]);
		}
		

		coinsLabel.text = coins+"";
		fruitsLabel.text = fruits+"/"+full;
*/


	}
	void onClose() {
		NGUITools.Destroy(this.transform.gameObject);
	}

	internal void setCoins(int coins){this.coins=coins;}

	internal void setFruits(int fruits, int full){this.fruits=fruits; this.full=full;}

}
