using UnityEngine;
using System.Collections;

public class Mining : MonoBehaviour {

    private bool animationIsRunning = false;

    public LayerMask toCast;	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && !animationIsRunning) {
            float angle;
            

            Vector2 convertedMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickDirection = convertedMousePosition - (Vector2)this.transform.GetChild(0).position;
            angle = (Mathf.Atan2(clickDirection.y, clickDirection.x) * Mathf.Rad2Deg);

            transform.GetChild(0).rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Debug.DrawRay(this.transform.GetChild(0).position, clickDirection.normalized * 0.4f);

            RaycastHit2D hit = Physics2D.Raycast(this.transform.GetChild(0).position, clickDirection.normalized, 0.4f, toCast);
            if (hit) {
                if (hit.collider.gameObject.GetComponent<BlockProperties>().health <= 0) { 
                    Destroy(hit.collider.gameObject);
                }
                else { 
                    hit.collider.gameObject.GetComponent<BlockProperties>().health--;
                    EdgeCollider2D EC2D = hit.collider.transform.GetComponent<EdgeCollider2D>();
                    Vector2[] points = EC2D.points;
                    Vector2 midWay = (points[0] - points[1]);
                    Debug.DrawRay(transform.position, EC2D.points[0], Color.blue, 5);
                    Debug.DrawRay(transform.position, points[1], Color.blue, 5);
                    EdgeCollider2D temp = EC2D.gameObject.AddComponent<EdgeCollider2D>();
                    temp.points = new Vector2[] {points[0], midWay };
                    EdgeCollider2D temp2 = EC2D.gameObject.AddComponent<EdgeCollider2D>();
                    temp.points = new Vector2[] { midWay, points[1] };
                }
            }
            StartCoroutine(Mine());
            

        }
    }

    IEnumerator Mine() {
        animationIsRunning = true;
        yield return new WaitForSeconds(0.02f);
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -10);
        yield return new WaitForSeconds(0.02f);
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -10);
        yield return new WaitForSeconds(0.02f);
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -10);
        yield return new WaitForSeconds(0.02f);
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -10);
        yield return new WaitForSeconds(0.02f);
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -10);
        yield return new WaitForSeconds(0.02f);
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -10);
        yield return new WaitForSeconds(0.02f);
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -10);
        yield return new WaitForSeconds(0.02f);
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -10);
        yield return new WaitForSeconds(0.02f);
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -10);
        animationIsRunning = false;
    }





}
