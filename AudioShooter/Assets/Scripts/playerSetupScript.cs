using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(playerManagerScript))]
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

        GetComponent<playerManagerScript>().Setup();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        playerManagerScript _player = GetComponent<playerManagerScript>();

        gameManagerScript.RegisterPlayer(_netID, _player);
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

        gameManagerScript.UnRegisterPlayer(transform.name);        
    }
}
