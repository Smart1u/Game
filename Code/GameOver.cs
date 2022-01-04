using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameOver : MonoBehaviour 
{
    void Update() 
    {
        if (GetComponent <Health_Hero> ().HealthHero <= 0) 
        {
            SceneManager.LoadScene(2);
        }
    }
}
