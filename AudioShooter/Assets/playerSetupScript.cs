using UnityEngine;
using UnityEngine.Networking;

public class playerSetupScript : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componenetsToDisable;

    Camera sceneCamera;

    void Start ()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componenetsToDisable.Length; i++)
            {
                componenetsToDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                Camera.main.gameObject.SetActive(false);
            }
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
