using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu_Buttons : MonoBehaviour
{
    public void GoPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void FullGameExit()
    {
        Application.Quit();
    }

    public void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
