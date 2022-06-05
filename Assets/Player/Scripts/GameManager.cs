using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private const string playerIdPrefix = "player";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public MatchSettings matchSettings;

    public static GameManager instance;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            if (SplashScreen.isFinished)
            {

            }
            return;
        }

        print("plus d'une instance de game manager dans la scene");
    }

    public static void RegisterPlayer(string netID, Player player)
    {
        string playerId = playerIdPrefix + netID;
        players.Add(playerId, player);
        player.transform.name = PlayerPrefs.GetString("PlayerName");
    }

    public static void UnregisterPlayer(string playerid)
    {
        players.Remove(playerid);
    }

    public static Player GetPlayer(string playerId)
    {
        return players[playerId];
    }

    private void OnGUI()
    {


        {
            GUILayout.BeginArea(new Rect(200, 200, 200, 500));
            GUILayout.BeginVertical();
            string content= "non";
            foreach (string playerId in players.Keys)
            {
                GUILayout.Label(playerId + " - " + players[playerId].transform.name);
            }

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}