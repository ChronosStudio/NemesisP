using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Options : MonoBehaviour
{
    public GameObject Panel;
    bool visible = true;

    public TMP_Dropdown DResolution;

    void Update()
    {
        PauseMenu.isOn = true;

        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void SetResolution()
    {
        switch(DResolution.value)
        {
            case 0:
                Screen.SetResolution(640,360,true);
                break;

            case 1:
                Screen.SetResolution(1920,1080,true);
                break;
        }
    }
}
