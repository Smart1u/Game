using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class MenuGame : MonoBehaviour
{
    public GameObject Menu; 
    public camera Sens; 
    public AttackPlyer hit;
    public GameObject shopmenu;
    public Shop shop;
    public Trader t;
    public GameObject trader;
    public Qest q;
    public GameObject Qestboard;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && shop.a == 0 && q.w == 0) 
        {
            Qestboard.SetActive(false);
            trader.SetActive(false);
            t.menuactive = true;
            Menu.SetActive(true); 
            Cursor.lockState = CursorLockMode.Confined; 
            UnityEngine.Cursor.visible = true; 
            Time.timeScale = 0f; 
            Sens.mouseSens = 0; 
            hit.menu = true;
        }
        else
        {
        }
    }
    public void Resume() 
    {
            Qestboard.SetActive(true);
            trader.SetActive(true);
            t.menuactive = false;
            Menu.SetActive(false); 
            Cursor.lockState = CursorLockMode.Locked; 
            UnityEngine.Cursor.visible = false; 
            Time.timeScale = 1f; 
            Sens.mouseSens = 6; 
            hit.menu = false;
    }
    public void ExiteMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
