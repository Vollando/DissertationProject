using UnityEngine.Networking;
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
                CmdPlayerShot(_hit.collider.name, weapon.damage);
            }
        }
    }

    [Command]
    void CmdPlayerShot (string _playerID, int _damage)
    {
        Debug.Log(_playerID + " has been shot.");

        playerManagerScript _player = gameManagerScript.GetPlayer(_playerID);
        _player.TakeDamage(_damage);
    }
}
