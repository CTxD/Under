using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


    //Goes on: Camera
    //Needs: Reference to player gameobject

    public GameObject Player;
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPosition = Player.transform.position; //Get the player position
        playerPosition.z -= 1; //offset the camera from the game
        this.transform.position = playerPosition; //Set the new camera position

	}
}
