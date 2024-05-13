using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameWorld_Buttons : MonoBehaviour
{
    public GameObject Pause_Menu;
    public GameObject _player;

    public void GameContinue()
    {
        var _isOpen = _player.GetComponent<OpenPauseMenu>()._pause_open;

        _isOpen = !_isOpen;
        Pause_Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void GameWorld_Exit()
    {
        SceneManager.LoadScene(0);
    }
}
