using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour {

	public float speed = 100.0f;
	public int force;
	public GameObject ball;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>(); 
		rb.velocity = Vector2.down * speed;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -130) {
			Instantiate(ball, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
			Destroy(gameObject);
		}
		rb.AddForce(new Vector2(force, force));
	}


	void OnCollisionEnter2D(Collision2D collision2D) {

		if (collision2D.gameObject.tag == "Platform") {
			float x=  hitFactor(transform.position, collision2D.transform.position, collision2D.collider.bounds.size.x);
			Vector2 direction = new Vector2(x, 1).normalized;
			GetComponent<Rigidbody2D>().velocity = direction * speed;
		}

		if (collision2D.gameObject.tag == "Block")
		{
			ScoreScript.score++; 
			Destroy(collision2D.gameObject);
		}

		if (collision2D.gameObject.tag == "BorderBottom")
		{
			ScoreScript.score = 0;
			LoadStartScene ();
		}
	}

	private void LoadStartScene() {
		SceneManager.LoadScene ("start-scene");	
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
		return (ballPos.x - racketPos.x) / racketWidth;
	}
}
