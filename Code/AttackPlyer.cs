using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackPlyer : MonoBehaviour 
{
    public bool menu = false;
    void Update() 
    {
        if(Input.GetButtonDown ("Fire1") && menu !=true ) 
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack1");
        }
    }
}
