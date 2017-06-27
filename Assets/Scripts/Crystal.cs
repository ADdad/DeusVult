using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {

	

	public enum Color
	{
    	RED = 0,
    	GREEN = 1,
    	BLUE = 2
	}

	public Color col = Color.RED;
	protected override void OnRabbitHit (HeroKnight kng)
	{
		kng.addDMG();
		this.CollectedHide();
	}
}
