using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour {

        AudioSource audioSource;
        public AudioClip wallAudio;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit Wall");
            audioSource.clip = wallAudio;
            audioSource.Play();
        }
    }
}
