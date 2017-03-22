using UnityEngine;
using UnityEngine.Networking;

public class playerSetupScript : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componenetsToDisable;
    public Behaviour PlayerComponentToDisable;

    Camera sceneCamera;

    void Start ()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
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
    }

    void DisableComponents ()
    {
        for (int i = 0; i < componenetsToDisable.Length; i++)
        {
            componenetsToDisable[i].enabled = false;
        }
    }

    void onDisable ()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }   
    }
}
