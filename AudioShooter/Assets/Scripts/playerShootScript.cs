using UnityEngine.Networking;
using UnityEngine;

public class playerShootScript : NetworkBehaviour {

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

    void Shoot ()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            Debug.Log("Hit" + _hit.collider.name);
        }
    }
}
