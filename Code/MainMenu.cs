using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame() // создание метода new game
    {
        
        SceneManager.LoadScene(1); // переход на сцену 1 - новая игра 
    }
    public void ExiteGame() // создание метода
    {
        Application.Quit(); // выход из приложения 
    }
}
