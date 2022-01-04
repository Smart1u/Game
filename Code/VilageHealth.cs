using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VilageHealth : MonoBehaviour
{
    public int Healthvilage = 2000;
    public Slider mySlider;   
    public Image myImage;
    public Text Count;
    void Update()
    {
        mySlider.value = Healthvilage;
        Count.text = Healthvilage + " / " + 2000;
        if (Healthvilage <= 0) // Берёт компонент Health_Hero переменной HealthHero сравнивает его с нулём
        {
            SceneManager.LoadScene(3); // переход на сцену 2 - экран смерти
        }
        if (Healthvilage <= 0)   // если переменная здоровья будет меньше или равна 0 то
        {
            myImage.enabled = false;   // переменная изображения выключается ползунок будет пустым
        }
        else
        {
            myImage.enabled = true;   // переменная изображения включается ползунок будет полным
        }
    }
}
