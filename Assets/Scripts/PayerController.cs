using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
//		Destroy(other.gameObject);
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive (false);

			count++;
			SetCountText ();
			if (CheckWinCondition ()) {
				winText.text = "You Win!";
			}

		}

	}

	bool CheckWinCondition() {
		List<GameObject> go = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Pick Up"));
		return go.TrueForAll (x => !x.activeSelf);
	}

}
