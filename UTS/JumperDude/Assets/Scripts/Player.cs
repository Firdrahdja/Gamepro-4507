using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	Rigidbody2D rb;
	Animator anim;
	bool facingRight = true;
	float velX, speed = 2f;
	public float jumpAmount = 10;	
	int health = 10;
	bool isHurt, isDead;
	
    // Start is called before the first frame update
    void Start() {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();        
    }

    // Update is called once per frame
    void Update() {
		if (Input.GetKey (KeyCode.LeftShift))
			speed = 5f;
		else
			speed =  2f;
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
		}
		
		AnimationState();
		
		if (!isDead)		
		velX = Input.GetAxisRaw ("Horizontal") * speed;
        
    }
	
	void FixedUpdate() {
		if (!isHurt)
		rb.velocity = new Vector2 (velX, rb.velocity.y);
	}
	
	void LateUpdate() {
		CheckWhereToFace();
	}
	
	void CheckWhereToFace () {
		Vector3 localScale = transform.localScale;
		if (velX > 0) {
			facingRight = true;
		} else if (velX < 0) {
			facingRight = false;
		}
		if ((facingRight) && (localScale.x < 0) || (!facingRight) && (localScale.x > 0)) {
			localScale.x *= -1;
		}
		
		transform.localScale = localScale;
	}
	
	void AnimationState(){
		if (velX == 0){
			anim.SetBool("isRunning", false);
		}
		if (rb.velocity.y == 0) {
			anim.SetBool ("isJumping", false);
			anim.SetBool ("isFalling", false);
			
		}
		if (Mathf.Abs(velX) == 2)
			anim.SetBool ("isRunning", true);
		
		if (rb.velocity.y > 2)
			anim.SetBool ("isJumping", true);
		if (rb.velocity.y < -1) {
			anim.SetBool ("isJumping", false);
			anim.SetBool ("isFalling", true);
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag.Equals ("Spike")){
			health -= 1;
		}
		
		if (col.gameObject.tag.Equals ("Spike") && health > 0){
			anim.SetTrigger ("isHurt");
			StartCoroutine ("Hurt");
		} else {
			velX = 0;
			isDead =  true;
			anim.SetTrigger ("isDead");
		}
	}
	
	IEnumerator Hurt () {
		isHurt = true;
		rb.velocity = Vector2.zero;
		
		if (facingRight)
			rb.AddForce (new Vector2(-100f, 100f));
		else
			rb.AddForce (new Vector2(100f, 100f));
		
		yield return new WaitForSeconds (0.5f);
		
		isHurt = false;
	}
}
