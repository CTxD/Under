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
