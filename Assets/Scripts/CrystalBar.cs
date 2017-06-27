using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBar : MonoBehaviour {

 	GameObject grandChild;
    int chld = 0;
    public Sprite red, green, blue;
    public int[] colir = {-1,-1,-1};

    public enum Color
	{
    	RED = 0,
    	GREEN = 1,
    	BLUE = 2
	}


    public void add(int col)
    {   
        colir[chld]=col;
    	Color color = (Color)col;
        grandChild = this.gameObject.transform.GetChild(chld).gameObject;
        switch(color) {
        	case Color.RED: grandChild.GetComponent<UI2DSprite>().sprite2D = red;
        	break;
        	case Color.GREEN: grandChild.GetComponent<UI2DSprite>().sprite2D = green;
        	break;
        	case Color.BLUE: grandChild.GetComponent<UI2DSprite>().sprite2D = blue;
        	break;
        }
        chld++;

    }

    public void loadSprites(Sprite red, Sprite green, Sprite blue){
        this.red = red;
        this.green = green;
        this.blue = blue;
    }

    public int collectedCrystals(){return chld;}
}
