using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class NetworkManagerMenu : NetworkBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Canvas MainMenu;

    [SerializeField] private NetworkManager manager;

    public void StartHostGame()
    {
        manager.StartHost();
    }

    public void StartClientGame()
    {
        manager.StartClient();
        manager.networkAddress = inputField.text;
        if (NetworkClient.isConnected)
        {
            MainMenu.gameObject.SetActive(false);
        }
    }

    public void StopClient()
    {
        if (isClientOnly)
        {
            manager.StopClient();
        }
        else
        {
            manager.StopServer();
        }
    }

    private void Update()
    {
        if (NetworkClient.isConnected && MainMenu.gameObject.active)
        {
            MainMenu.gameObject.SetActive(false);
        }
        if (!NetworkClient.isConnected && !MainMenu.gameObject.active)
        {
            MainMenu.gameObject.SetActive(true);
        }
    }
}
