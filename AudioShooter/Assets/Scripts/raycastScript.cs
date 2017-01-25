using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("aiming at other player!");
            }
        }
        else Debug.Log("");

    }
}
