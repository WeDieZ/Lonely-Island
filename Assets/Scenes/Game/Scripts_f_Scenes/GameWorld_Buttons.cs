using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameWorld_Buttons : MonoBehaviour
{
    public GameObject Pause_Menu;
    public GameObject _player;
    public PlayerController activity;

    public void GameContinue()
    {
        var cameraRotation = _player.GetComponent<CameraRotation>();
        var hp_and_food = _player.GetComponent<HP_Food_Script>();

        Pause_Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraRotation.enabled = true;
        hp_and_food.enabled = true;
        activity.IsAbleToMove = true;
    }

    public void GameWorld_Exit()
    {
        SceneManager.LoadScene(0);
    }
}
