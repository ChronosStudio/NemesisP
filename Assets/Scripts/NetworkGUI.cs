using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkGUI : NetworkBehaviour
{
    NetworkManager manager;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Canvas MainMenu;

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

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

    void Update()
    {
        if (NetworkClient.isConnected && MainMenu.gameObject.activeSelf)
        {
            print("true");
            MainMenu.gameObject.SetActive(false);
        }
        if (!NetworkClient.isConnected && !MainMenu.gameObject.activeSelf)
        {
            print("dfalse");
            MainMenu.gameObject.SetActive(true);
        }
    }


}
