﻿using UnityEngine.Networking;
using UnityEngine;

public class playerShootScript : NetworkBehaviour {

    private const string PLAYER_TAG = "Player";

    public playerWeaponScript weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("Playershoot: no Camera Referenced!");
            this.enabled = false;
        }
    }


    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot ()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            if (_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerShot (string _ID)
    {
        Debug.Log(_ID + " has been shot.");
    }
}
