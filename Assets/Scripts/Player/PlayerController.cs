using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a"))
            this.transform.Translate(Vector2.left * Time.deltaTime);
        if (Input.GetKey("d"))
            this.transform.Translate(Vector2.right * Time.deltaTime);
        if (Input.GetKeyDown("space")) { 
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse);
        }
    }
}
