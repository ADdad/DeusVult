using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics {

		public bool all_crystals = false;
		public bool level1 = false;
		public bool level2 = false;
		public int coins = 0;
		public bool[] fruits = null;
		public int colectedFruits = 0;

	public static PlayerStatistics ps = new PlayerStatistics();
}
