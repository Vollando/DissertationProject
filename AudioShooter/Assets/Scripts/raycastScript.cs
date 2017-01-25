using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastScript : MonoBehaviour {

    CharacterController charCtrl;

	// Use this for initialization
	void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        CharacterController charContr = GetComponent<CharacterController>();
        Vector3 p1 = transform.position + charContr.center + Vector3.left * -charContr.height * 0.5f;
        Vector3 p2 = p1 + Vector3.left * charContr.height;
        float distanceToObstacle = 0;

        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("aiming at other player!");
            }
        }
        else Debug.Log("");

        if (Physics.CapsuleCast(p1, p2, charContr.radius, transform.forward, out hit, 5))
        {
            distanceToObstacle = hit.distance;
            Debug.Log(hit.distance);
        }

    }
}
