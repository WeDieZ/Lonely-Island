using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{   
    public GameObject Pause_Menu;
    public bool _pause_open = false;

    private void Update()
    {
        Open_Close_Menu();
    }

    private void Open_Close_Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pause_open = !_pause_open;
            if (_pause_open == true)
            {
                Pause_Menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
        }
    }
}
