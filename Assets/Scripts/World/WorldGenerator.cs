using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	public GameObject tile;
	public int worldXBlocks = 30, worldYBlocks = 10;

	private int[,] world;

	// Calculate blocks / camX, blocks / camY
	private float blocksX, blocksY;

	// Use this for initialization
	void Start () {
		// Define world size (number of blocks)
		world = new int[30, 30]; 

		// Calculate block width and height
		float tileWidth = tile.GetComponent<SpriteRenderer> ().bounds.size.x;
		float tileHeight = tile.GetComponent<SpriteRenderer> ().bounds.size.y;

		// Calculating Camera bounds
		float camPosX = Camera.main.transform.position.x;
		float camPosY = Camera.main.transform.position.y;
		float camHeight = Camera.main.orthographicSize * 2f;
		float camWidth = camHeight * Screen.width / Screen.height;

		// Calculate blocks / camX, blocks / camY
		blocksX = camWidth / tileWidth;
		blocksY = camHeight / tileHeight / 2 + 1;

		for (int x = 0; x < blocksX; x++) {
			for(int y = 0; y < blocksY; y++){
				Instantiate (tile, new Vector3 ((camPosX - camWidth / 2) + x * tileWidth, -y * tileHeight, 0), Quaternion.identity);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
