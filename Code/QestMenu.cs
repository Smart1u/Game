using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QestMenu : MonoBehaviour
{
    public GameObject Qest;
    public camera Sens;
    public MenuGame menu;
    public bool menuactive = false;
    public AttackPlyer attack;
    public Qest qest;
    
   


    void Update()
    {
        
        RaycastHit hit;
        if (menuactive != true)
        {

            if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
            {
                if (hit.collider.tag == ("Qestbord"))
                {
                    

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        qest.w = 1;
                        attack.menu = true;
                        Cursor.lockState = CursorLockMode.Confined;
                        UnityEngine.Cursor.visible = true;
                        Time.timeScale = 0f;
                        Sens.mouseSens = 0;
                        Qest.SetActive(true);





                    }
                    else
                    {

                    }
                }
                else
                {
                    
                }
            }
            else
            {


            }
        }
        else
        {

        }
    }
}
