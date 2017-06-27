using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class Collectable : MonoBehaviour {
		protected virtual void OnRabbitHit(HeroKnight rabit) {
		}


		void OnTriggerEnter2D(Collider2D collider) {
			//if(!this.hideAnimation) {
				HeroKnight rabit = collider.GetComponent<HeroKnight>();
				if(rabit != null) {
				this.OnRabbitHit (rabit);
				}
			//}
		}

		public void CollectedHide() {
			Destroy(this.gameObject);
		}
	}