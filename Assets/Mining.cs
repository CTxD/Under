using UnityEngine;
using System.Collections;

public class Mining : MonoBehaviour {

    public LayerMask toCast;
    private float t = 0.0f;
    private bool isMining = false;
    private Vector2 mousePositionToAnimate;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 convertedMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickDirection = convertedMousePosition - (Vector2)this.transform.GetChild(0).position;
            float angle = (Mathf.Atan2(clickDirection.y, clickDirection.x) * Mathf.Rad2Deg) - 50;

            transform.GetChild(0).rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, 90);
            Debug.DrawRay(this.transform.GetChild(0).position, clickDirection.normalized * 0.4f);
               RaycastHit2D hit = Physics2D.Raycast(this.transform.GetChild(0).position, clickDirection.normalized, 0.4f, toCast);
            if (hit)
                Destroy(hit.transform.gameObject);
            isMining = true;
            mousePositionToAnimate = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            t = 0.0f;
        }

        if (t < 1.0 && isMining)
        {
            t += Time.deltaTime;
            Mine();
        }
        else
            isMining = false;

	}

    void Mine()
    {
        Vector2 clickDirection = mousePositionToAnimate - (Vector2)this.transform.GetChild(0).position;
        float angle = (Mathf.Atan2(clickDirection.y, clickDirection.x) * Mathf.Rad2Deg) - 50;
        transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, Quaternion.Euler(transform.GetChild(0).rotation.x, transform.GetChild(0).rotation.y, 90), Time.deltaTime * 6f);
        
    }


}
