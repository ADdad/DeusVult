using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PlayerStats : MonoBehaviour {

	bool[] all_crystals = null;
	bool level1 = false;
	bool level2 = false;
	int coins = 0;
	int coins2 = 0;
	public bool[] fruits = null;
	public bool[] fruits2 = null;

	public static PlayerStats stat = new PlayerStats();


	public void setCoins(int coins){this.coins=coins;}
	public void addFruit(int id){fruits[id]=true;
	}
	public void setMaxFruits(int quantity, int lvl){
		string str = PlayerPrefs.GetString ("stats", null);
		if(str!=null){
		LevelStat ls = JsonUtility.FromJson<LevelStat>(str);
		if(lvl==1)fruits = ls.fruits;
		if(lvl==2)fruits = ls.fruits2;
		}
		if(fruits==null)fruits = new bool[quantity];
		else if(quantity>fruits.Length)fruits = new bool[quantity];
	}
	public void setMaxFruits2(int quantity){
		
		if(fruits2==null)fruits = new bool[quantity];
		else if(quantity>fruits2.Length)fruits2 = new bool[quantity];
	
	}
	public void endLevel1(bool isit){level1=isit;}
	public void endLevel2(bool isit){level2=isit;}
	public void allCrystalsSet(int level,bool isit){
		if(all_crystals==null)all_crystals=new bool[2];
		all_crystals[level]=isit;
	}
	public void addCoin(int lvl){if(lvl==1)coins++;
		else coins2++;
	}


	public int getCoins(){return coins;}
	public int getCoins2(){return coins2;}
	public bool isLevelEnded(int n){
		if(n==1)return level1;
		else return level2;
	}
	public bool isLevel2Ended(){return level2;}
	public bool allCrystalsGet(int level){return all_crystals[level];}
	public int getMaxFruits(){return fruits.Length;}
	public int getMaxFruits2(){return fruits.Length;}
	public int collectedFruits(){
		
		if(fruits==null)return 0;
		int col = 0;
		for(int i=0; i<fruits.Length; i++){if(fruits[i])col++;}
		return col;
	}

	

	public void saveStatistics(){
		LevelStat ls = new LevelStat();
		ls.all_crystal = PlayerStats.stat.all_crystals;
		ls.level1 = PlayerStats.stat.isLevelEnded(1);
		ls.level2 = PlayerStats.stat.isLevelEnded(2);
		ls.coins = PlayerStats.stat.getCoins();
		ls.coins2 = PlayerStats.stat.getCoins2();
		if(LevelController.current.Level==1){
			if(PlayerStats.stat.collectedFruits()==PlayerStats.stat.getMaxFruits())ls.allFruits1=true;
		ls.fruits = PlayerStats.stat.fruits;} 
		if(LevelController.current.Level==2){
			ls.fruits2 = PlayerStats.stat.fruits;
			if(PlayerStats.stat.collectedFruits()==PlayerStats.stat.getMaxFruits())ls.allFruits1=true;
		}
		PlayerStats.stat.fruits = null;
		string str = JsonUtility.ToJson(ls);
		PlayerPrefs.SetString("stats", str);
		PlayerPrefs.Save();
	}

	public void loadStatistics(){
		stat = new PlayerStats();
	}


	
}
