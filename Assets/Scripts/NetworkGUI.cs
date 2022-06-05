using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(NetworkManager))]
public class NetworkGUI : MonoBehaviour
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
        if(NetworkClient.isConnected)
        {
            MainMenu.gameObject.SetActive(false);
        }
    }

    public void StopClient()
    {
        manager.StopClient();
        manager.StartServer();
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
