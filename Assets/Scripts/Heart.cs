using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Collectable {



	protected override void OnRabbitHit (HeroKnight kng)
	{
		kng.addHP(20f);
		this.CollectedHide();
	}


}
