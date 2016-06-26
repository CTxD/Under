using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public bool isFlipped = false;

	// Use this for initialization
	void Start () {
	
	}
	
    bool isGrounded(GameObject GO) {
        RaycastHit2D[] hits; // to store what we hit with the raycast
        float objectHeight = GO.GetComponent<BoxCollider2D>().bounds.size.y / 2; //Height based off of object, with transform being at center.
        Vector2 down = new Vector2(0, -1); //make a down vector
        hits = Physics2D.RaycastAll(GO.transform.position, down, objectHeight+0.01f); //do the raycast, store the result in hits
        return (hits.Length > 1); //Return if we hit anything else than the player, ensuring we actually hit something.
    }

    void Jump() {
        if(isGrounded(this.gameObject)) //Check if we are grounded, to prevent jumping in mid air.
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse); //Add the jump force
    }

    // Update is called once per frame
    void Update() {
        //Move left
        if (Input.GetKey("a") || Input.GetKey("left")) {
            isFlipped = false;
        this.transform.Translate(Vector2.left * Time.deltaTime);
        Quaternion tempVect = this.transform.rotation;
        tempVect.y = 0;
        this.transform.rotation = tempVect;
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }

        //move right
        if (Input.GetKey("d") || Input.GetKey("right")) {
            isFlipped = true;

            Quaternion minerRot = this.transform.rotation;
            minerRot.y = 180;
            this.transform.rotation = minerRot;
            this.transform.Translate(Vector2.left * Time.deltaTime);
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }

        //Jump
        if (Input.GetKeyDown("space")) {
            Debug.Log(isGrounded(this.gameObject));
            Jump();
        }
    }
}
