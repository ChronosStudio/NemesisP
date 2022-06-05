using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isOn = false;
    [SerializeField] private Canvas pauseMenu;

    public void setPauseMenuOn()
    {
        isOn = true;
        pauseMenu.gameObject.SetActive(true);
    }

    public void setPauseMenuOff()
    {
        isOn = false;
        pauseMenu.gameObject.SetActive(false);
    }

}
