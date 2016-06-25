using UnityEngine;
using System.Collections;

public class Mining : MonoBehaviour {

    //Y-Axis bug on animation

    public LayerMask toCast;
    private float t = 0.0f;
    private bool isMining = false;
    private bool active = false;
    private Vector2 mousePositionToAnimate;
    private Quaternion endPosition;
    public int offset = 0;
    int count = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {


            if (!active) {
                active = true;
                isMining = true;
                count = 0;
                mousePositionToAnimate = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 convertedMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 clickDirection = convertedMousePosition - (Vector2)this.transform.GetChild(0).position;
                float angle = (Mathf.Atan2(clickDirection.y, clickDirection.x) * Mathf.Rad2Deg);



                transform.GetChild(0).rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                Debug.DrawRay(this.transform.GetChild(0).position, clickDirection.normalized * 0.4f);
                RaycastHit2D hit = Physics2D.Raycast(this.transform.GetChild(0).position, clickDirection.normalized, 0.4f, toCast);
                if (hit)
                    Destroy(hit.transform.gameObject);
            }




        }

        if (isMining && count < 20)
        {
            StartCoroutine(Mine());
            offset += 5;
        }
        else {
            active = false;
            isMining = false;
            offset = 0;
        }
    }


    IEnumerator Mine()
    {
        
        float angle = (Mathf.Atan2(mousePositionToAnimate.y, mousePositionToAnimate.x) * Mathf.Rad2Deg);
        transform.GetChild(0).rotation = Quaternion.AngleAxis(angle - offset, Vector3.forward);
        Debug.Log("VLA");
        count += 1;
        yield return new WaitForSeconds(0.5f);
    }

}
