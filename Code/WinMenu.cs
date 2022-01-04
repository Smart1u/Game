using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public camera Sens;
    public AttackPlyer hit;

    public void Resume()
    {
        Time.timeScale = 1f; // Скорость игры = 1
        Sens.mouseSens = 6; // Устанавливает Чувствительность мыши камеры на 6
        hit.menu = false;
        UnityEngine.Cursor.visible = false; // Курсор Скрыть
        Cursor.lockState = CursorLockMode.Locked; // Курсор заблокировать
    }
    public void Exite()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
