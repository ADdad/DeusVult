using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrc : MonoBehaviour {

	public enum Mode {
		GoToA,
		GoToB,
		Attack,
		Triggered,
		Dead,
		Attacked
	}

	Mode mode = Mode.GoToA;

	public Vector3 pointA;
	public Vector3 pointB;
	public float dmg = 20;
	public AudioClip attackSound = null;
	AudioSource attackSource = null;

	public float speed = 1;
	public int healt = 2;
	float startPoint, finishPoint;

	Rigidbody2D myBody = null;

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		startPoint = Mathf.Min(pointA.x, pointB.x);
		finishPoint = Mathf.Max(pointA.x, pointB.x);

		attackSource = gameObject.AddComponent<AudioSource> ();
		attackSource.clip = attackSound;
	}
	
	// Update is called once per frame
	void Update () {
		Animator animator = GetComponent<Animator>();
		if(mode==Mode.GoToA || mode==Mode.GoToB){
			animator.SetBool("walk",true);}
		if(mode==Mode.Triggered)animator.SetBool("run",true);
		else animator.SetBool("run",false);
		if(mode==Mode.Attack){
			animator.SetTrigger("attack");
		}
		if(mode==Mode.Attacked)animator.SetTrigger("attacked");
	}

	void FixedUpdate(){
		//moving
		float value = this.getDirection();
		SpriteRenderer sr = GetComponent<SpriteRenderer>();

		if (value<0) sr.flipX = true;
		else if (value>0) sr.flipX = false;

		

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		}

	}

	void attackHero(){
		GetComponent<SpriteRenderer>().color = Color.white;
		if(mode==Mode.Attack)HeroKnight.lastKnight.orcAttack(dmg/100);
		mode = Mode.GoToA;
	}

	float getDirection(){
		Vector3 my_pos = this.transform.position;
		Vector3 rabbit_pos = HeroKnight.lastKnight.transform.position;
		
		if(rabbit_pos.x>startPoint
			&& rabbit_pos.x<finishPoint && mode!=Mode.Attack 
			&& Mathf.Abs(rabbit_pos.y-my_pos.y)<GetComponent<BoxCollider2D>().size.y) mode=Mode.Triggered;
		else if(mode==Mode.Triggered) mode = Mode.GoToA;
		
		if(mode==Mode.GoToA){
			if(my_pos.x > startPoint)return -1;
			else {
				mode = Mode.GoToB;
				return 1;
			}
		}
		if(mode==Mode.GoToB){	
			if(my_pos.x < finishPoint)return 1;
			else {
				mode = Mode.GoToA;
				return -1;
			}
		}
		if(mode==Mode.Triggered){
			//Move towards rabbit
			if(my_pos.x < rabbit_pos.x)return 2;
			else return -2;
		}
		return 0;
	}

	void OnCollisionEnter2D(Collision2D col){
		Collider2D collider = col.collider;
		if(col.transform.tag == "Player")
		{
			Vector3 contactPoint = col.contacts[0].point;
            float up = this.GetComponent<BoxCollider2D>().bounds.max.y;
 			
 			if(HeroKnight.lastKnight.attacks){
 				healt-=HeroKnight.lastKnight.dmg;
 				if(healt<=0){
 				mode=Mode.Attacked;}
 				else GetComponent<SpriteRenderer>().color = Color.red;
 			}
			else {
				mode=Mode.Attack;
			}
		}
	}

	public void DestroyOrc(){
		Destroy(this.gameObject);
	}

	void OnCollisionExit2D(Collision2D col){
			if(col.transform.tag == "Player")
			{
			mode=Mode.GoToA;
			}
	}

	void attackPlay(){
		if(SoundManager.Instance.isSoundOn()) {
				attackSource.Play();	
			}
		
	}

}
