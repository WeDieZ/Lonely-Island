using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{   
    public GameObject Pause_Menu;
    public PlayerController activity;
    public GameObject _player;
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
                var cameraRotation = _player.GetComponent<CameraRotation>();
                var hp_and_food = _player.GetComponent<HP_Food_Script>();

                Pause_Menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                cameraRotation.enabled = false;
                hp_and_food.enabled = false;
                activity.IsAbleToMove = false;
            }
        }
    }
}
