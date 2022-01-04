using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Trader : MonoBehaviour
{
    public GameObject ShopMenu;
    public camera Sens;
    public Shop shop;
    public MenuGame menu;
    public bool menuactive = false;
    public AttackPlyer attack;
    void Update()
    {
       RaycastHit hit;
       if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f) & menuactive != true)
       {
         if (hit.collider.tag == ("Trader"))
         {
           if (Input.GetKeyDown(KeyCode.E))
           {
             attack.menu = true;
             shop.a = 1;
             Cursor.lockState = CursorLockMode.Confined;
             UnityEngine.Cursor.visible = true;
             Time.timeScale = 0f;
             Sens.mouseSens = 0;
             ShopMenu.SetActive(true);
           }
         }
       }
    }
}
