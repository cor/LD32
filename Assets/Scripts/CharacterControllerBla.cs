using UnityEngine;
using System.Collections;

public class CharacterControllerBla : MonoBehaviour {

	public float maxSpeed = 10f;

	Animator anim;
	Rigidbody2D rb;

	bool facingRight = true;
	bool onGround = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 100f;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveAxisValue = Input.GetAxis("Horizontal");

		onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

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

	void Update() {
		if (onGround && Input.GetAxis("Jump") == 1) {
			// Jump
			anim.SetBool("Ground", false);
			rb.AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1; // flip the transform
		transform.localScale = scale;
	}
}
