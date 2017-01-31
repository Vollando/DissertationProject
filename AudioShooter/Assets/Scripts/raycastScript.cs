using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastScript : MonoBehaviour {

    CharacterController charCtrl;

    AudioSource audioSource;
    public AudioClip proximityAudio;

    public float newDistance;
    public float audiovolume = 0.5f;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = audiovolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 cameraRadius = new Vector3(-2, 0, 0);

        CharacterController charContr = GetComponent<CharacterController>();
        Vector3 p1 = transform.position + charContr.center + cameraRadius * -charContr.height * 0.5f;
        Vector3 p2 = p1 + cameraRadius * charContr.height;
        float distanceToObstacle = 5;
      

        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("aiming at other player!");
                audioSource.clip = proximityAudio;
                audioSource.Play();
            }
        }
        else Debug.Log("");

        if (Physics.CapsuleCast(p1, p2, charContr.radius, transform.forward, out hit, 5))
        {
            newDistance = distanceToObstacle - hit.distance;
            for (int i = 0; i < newDistance; i++)
            {
                audiovolume = newDistance;
            }
            Debug.Log(newDistance);
        }

       

    }
}
