using UnityEngine;
using UnityEngine.Networking;

public class playerSetupScript : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componenetsToDisable;
    public Behaviour PlayerComponentToDisable;

    [SerializeField]
    private int remoteLayerName = 9;

    Camera sceneCamera;

    void Start ()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }
        else
        {
            PlayerComponentToDisable.enabled = false;
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                Camera.main.gameObject.SetActive(false);
            }
        }

        RegisterPlayer();

    }

    void RegisterPlayer ()
    {
        string _ID = "Player :" + GetComponent<NetworkIdentity>().netId;
        transform.name = _ID;
    }

    void DisableComponents ()
    {
        for (int i = 0; i < componenetsToDisable.Length; i++)
        {
            componenetsToDisable[i].enabled = false;
        }
    }

    void AssignRemoteLayer ()
    {
        gameObject.layer = remoteLayerName;
    }

    void onDisable ()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }   
    }
}
