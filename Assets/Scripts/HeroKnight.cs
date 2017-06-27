using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroKnight : MonoBehaviour {


	public float speed = 1;


	Rigidbody2D myBody = null;

	bool isGrounded = false;
	bool isDead = false;
	bool isBlocked = false;
	internal int size = 1;//size of the rabbit
	bool chk1 = true;
	bool shield1 = false;

	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;
	public int dmg = 1;

	public bool attacks = false;
	public MyHealth hl;
	public AtckStat at;
	float ghost_time = 12;
	float temp = 0;

	Transform heroParent = null;

	public static HeroKnight lastKnight = null;

	public AudioClip dieSound = null;
	public AudioClip walkSound = null;
	public AudioClip groundingSound = null;
	public AudioClip music = null;
	AudioSource dieSource = null;
	AudioSource moveSource = null;
	AudioSource groundSource = null;
	AudioSource musicSource = null;
	// Use this for initialization


	
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
		LevelController.current.setStartPosition(transform.position);
		this.heroParent = this.transform.parent;
		int s = PlayerPrefs.GetInt("damage", 0);
		if(s==0)dmg = 1;
		else dmg = s;

		dieSource = gameObject.AddComponent<AudioSource> ();
		moveSource = gameObject.AddComponent<AudioSource> ();
		groundSource = gameObject.AddComponent<AudioSource> ();
		dieSource.clip = dieSound;
		moveSource.clip = walkSound;
		groundSource.clip = groundingSound;

		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.clip = music;
		musicSource.loop = true;
		onMusic();	
	}

	public void onMusic(){
		if(SoundManager.Instance.isMusicOn())musicSource.Play();
	}

	public void offMusic(){
		musicSource.Stop();
	}
	
	void Awake() {
		lastKnight = this;
	}

	
	// Update is called once per frame
	void Update () {
		at.atck = dmg;
		float value = Input.GetAxis ("Horizontal");

		Animator animator = GetComponent<Animator>();
		if(Mathf.Abs(value)>0)animator.SetBool("run",true);
		else animator.SetBool("run", false);

		if(this.isGrounded)animator.SetBool("jump", false);
		else animator.SetBool("jump", true);


		if(this.isDead){
			animator.SetTrigger("dead");
		}

		if(Input.GetKeyDown(KeyCode.J)){
		animator.SetTrigger("attack");
		attacks = true;
		}
		if(Input.GetButton("Shield")){
			animator.SetBool("shield", true);
			shield1 = true;
		}
		else if(!Input.GetButton("Shield")){
			animator.SetBool("shield", false);
			shield1 = false;
		}
	}

	void endAttack(){attacks=false;}

	void FixedUpdate () {
		temp+=Time.deltaTime;
		if(temp>3)GetComponent<SpriteRenderer>().color = Color.white;

		ghost_time+=Time.deltaTime;
		
		float value = Input.GetAxis ("Horizontal");
		if(isBlocked)value=0;
		SpriteRenderer sr = GetComponent<SpriteRenderer>();

		if (value<0 && !shield1) sr.flipX = true;
		else if (value>0 && !shield1) sr.flipX = false;

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		}
		else moveSource.Stop();

		Vector3 from = transform.position+Vector3.down*1f;
		Vector3 to = transform.position+Vector3.down * 3f;
		int layer_id = 1 << LayerMask.NameToLayer("Ground");

		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		
		if(hit) {
			isGrounded = true;
			if(hit.transform != null && hit.transform.GetComponent<MovingPlatform>() != null){
				setNewParent(this.transform, hit.transform);
				if(chk1){
					groundSound();
					chk1=false;
				}
			}
		}
		else {
			chk1=true;
			isGrounded = false;
			setNewParent(this.transform, this.heroParent);
		}

		Debug.DrawLine(from, to, Color.red, 2f, false);

		if(Input.GetButtonDown("Jump") && isGrounded){
			this.JumpActive = true;
		}

		if(this.JumpActive){
			if(Input.GetButton("Jump")){
				this.JumpTime += Time.deltaTime;
				if(this.JumpTime<this.MaxJumpTime){
					Vector2 vel = myBody.velocity;
					vel.y = JumpSpeed*(1.0f - JumpTime/MaxJumpTime);
					myBody.velocity=vel;	
				}
			}
			else {
				this.JumpActive = false;
				this.JumpTime = 0;
			}
		}



	}

	static void setNewParent(Transform obj, Transform new_parent){
		if(obj.transform.parent != new_parent){
			Vector3 pos = obj.transform.position;
			obj.transform.parent = new_parent;
			obj.transform.position = pos;
		}
	}

	public void addHP(float hp){
		hl.Health_f+=(hp/100);
	}

	public void addDMG(){
		dmg++;
	}

	internal void orcAttack(float dmg){
		if((shield1==false) && ghost_time>12){
			GetComponent<SpriteRenderer>().color = Color.red;
			temp=0;
			hl.Health_f-=dmg;
			if(hl.Health_f<=0.01f){
			ghost_time=0;
			isDead=true;
			hl.Health_f=1f;
			if(SoundManager.Instance.isSoundOn()) {
				dieSource.Play();	
			}
		}
	}
	}


	void respawn(){
		GetComponent<SpriteRenderer>().color = Color.white;
		LevelController.current.onKnightDeath(this);
		isDead=false;
	}

	void moveSound(){
		if(SoundManager.Instance.isSoundOn() && !moveSource.isPlaying) {
				moveSource.Play();	
			}
	}


	void groundSound(){
		if(SoundManager.Instance.isSoundOn() && !groundSource.isPlaying) {
				groundSource.Play();	
			}
	}

	public void block(bool bl){isBlocked=bl;}
}
 