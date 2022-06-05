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
        //pauseMenu.gameObject.SetActive(true);
        setActiveR(pauseMenu.gameObject, true);
    }

    public void setPauseMenuOff()
    {
        isOn = false;
        setActiveR(gameObject, false);
    }

    private void setActiveR(GameObject obj, bool active)
    {
        obj.SetActive(active);
        foreach(Transform child in obj.transform)
        {
            setActiveR(child.gameObject, active);
        }
    }
}
