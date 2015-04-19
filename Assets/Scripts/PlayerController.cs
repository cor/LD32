using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;

	//components
	Animator anim;
	Rigidbody2D rb;

	bool facingRight = true;
	bool onGround = false;
	public bool playerCanShoot = false;

	public GameObject bullet;
	public Transform groundCheck;

	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 100f;
	public float delayBetweenShots = 3f;
	public float shootForce = 500f;
	public float timeUntilJetPizzaDespawn = 0.5f;

	private float timeSinceLastShot;


	private GameObject previousPizza;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		timeSinceLastShot = Time.time;
		previousPizza = new GameObject();
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

		if ((Input.GetAxis("Shoot") == 1) && (Time.time > timeSinceLastShot + delayBetweenShots)){
			Shoot();
		}

		if (Input.GetAxis("Fly") == 1) {
			Fly();
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1; // flip the transform
		transform.localScale = scale;
	}

	void Shoot() {

		if (playerCanShoot){

			if (facingRight) {
				Destroy(previousPizza);
				Vector3 clonePosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
				GameObject clone;
				clone = Instantiate(bullet, clonePosition, bullet.transform.rotation) as GameObject;
				clone.GetComponent<Rigidbody2D>().AddForce(Vector2.right * shootForce);
				previousPizza = clone;
			} else {
				Destroy(previousPizza);
				Vector3 clonePosition = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
				GameObject clone;
				clone = Instantiate(bullet, clonePosition, bullet.transform.rotation) as GameObject;
				clone.GetComponent<Rigidbody2D>().AddForce(Vector2.right * - shootForce);
				previousPizza = clone;
			}

			timeSinceLastShot = Time.time;

		}
	}

	void Fly() {
		Vector3 clonePosition = new Vector3(transform.position.x, transform.position.y -1.5f, transform.position.z);
		GameObject clone;
		clone = Instantiate(bullet, clonePosition, bullet.transform.rotation) as GameObject;
		clone.GetComponent<Rigidbody2D>().AddForce(Vector2.up * - shootForce);
		Destroy(clone, timeUntilJetPizzaDespawn);
	
	}
}
