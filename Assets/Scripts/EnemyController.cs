using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//components
	Animator anim;
	Rigidbody2D rb;

	bool facingRight = true;
	bool onGround = false;
	bool wallInFrontOfEnemy = false;

	public GameObject bullet;

	//collisions
	public Transform groundCheck;
	public Transform wallCheck;

	public LayerMask whatIsGround;
	public LayerMask whatIsWall;

	float groundRadius = 0.2f;
	float wallRadius = 0.2f;

	// speed constants
	public float jumpForce = 100f;
	public float delayBetweenShots = 3f;
	public float shootForce = 500f;
	public float timeUntilJetPizzaDespawn = 0.5f;
	public float maxSpeed = 10f;

	private float timeSinceLastShot;

	public float moveAxisValue = 1f;

	public int pizzaLayer = 10;

	public bool alive = true;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		timeSinceLastShot = Time.time;
	}
	
	void FixedUpdate () {
		if (alive) {
			// check if we're on the ground
			onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			wallInFrontOfEnemy = Physics2D.OverlapCircle(wallCheck.position, wallRadius, whatIsWall);

			if (wallInFrontOfEnemy) turnAround();

			// set animator values
			anim.SetBool("Ground", onGround);
			anim.SetFloat("VerticalSpeed", rb.velocity.y);
			anim.SetFloat("HorizontalSpeed", Mathf.Abs(moveAxisValue));

			rb.velocity = new Vector2(moveAxisValue * maxSpeed, rb.velocity.y); 

			// flip the transform when we're facing the wrong direction
			if (moveAxisValue > 0  && !facingRight)  {
				// walking right, facing left
				Flip ();
			}
			else if (moveAxisValue < 0 && facingRight) {
				// walking left, facing right
				Flip ();
			}
		}

	
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1; // flip the transform
		transform.localScale = scale;
	}

	void turnAround() {
		moveAxisValue *= -1;
	}

	void die() {
		alive = false;
		rb.fixedAngle = false;
		// set animator values
		anim.SetBool("Ground", true);
		anim.SetFloat("VerticalSpeed", 0);
		anim.SetFloat("HorizontalSpeed", 0);
	}


	void OnCollisionEnter2D(Collision2D col) {
		//layer 10 = Pizza
		if(col.gameObject.layer == pizzaLayer) {
			die();
		}
	}
}





