using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Подключение библиотеки ИИ Для распознования команды NavMeshAgent
using UnityEngine.UI; // Подключение библиотеки UI для распознования команд Slider Image

public class BanditEnemyQest : MonoBehaviour
{
    public float timerespawn = 15f;
    private NavMeshAgent myAgent; // Создание закрытой переменной NavMeshAgent с именем myAgent является переменной пола для врага
    private Animator myAnimator;// Создание закрытой переменной Animator с именем myAnimator является переменной анимации
    private float distance; // Создание закрытой переменной distance типа float является переменной радиуса обзора врага
    public Transform target;// Создание закрытой переменной Transform с именем target является целью для врага
    public Transform parking; // Создание закрытой переменной Transform с именем parking является зоной парковки врага
    public int HealthEnemy = 100; // Создание публичной переменной HealthEnemy типа int является количеством здоровья врага
    public int HealthEnemyMax = 100; // Создание публичной переменной HealthEnemy типа int является количеством максимального здоровья врага
    public Slider mySlider; // Создание публичной переменной Slider с именем mySlider ползунок здоровья врага
    public Image myImage; // Создание публичной переменной Image с именем myImage является цветом здоровья врага
    public GameObject HealthBarUI; // Создание публичной переменной GameObject с именем HealthBarUI игровой объект здоровья врага
    public int Enemyexp = 50; // Количество Опыта которое даёт враг при его убийстве
    private CharacterController myControl; //создание закрытой переменной CharacterController с именем myControl
    public Health_Hero Exp; // Создаётся переменная с привязкой к Health_Hero
    public bool isdead = false; // создаётся булевая переменная isdead
    public QestSpawn Spawn;

    public int moneydrop = 25;




    void Start() // Создание метода Start
    {

        HealthEnemy = HealthEnemyMax; // HealthEnemy Приравнивается к HealthEnemyMax
        mySlider.value = HealthEnemy; // mySlider.value Приравнивается HealthEnemy
        myAgent = GetComponent<NavMeshAgent>(); // myAgent берёт компонент NavMeshAgent
        myAnimator = GetComponent<Animator>(); // myAnimator берёт компонент Animator
        myControl = GetComponent<CharacterController>(); // myControl берёт компонент CharacterController


    }
    void Update() // Создание метода Update
    {




        if (HealthEnemy < HealthEnemyMax) //Если врагу нанесли урон его здоровье будет отображаться
        {
            HealthBarUI.SetActive(true); //активация здоровья врага
        }
        if (HealthEnemy > HealthEnemyMax) //приравнивает здоровье врага если оно выше максимального
        {
            HealthEnemy = HealthEnemyMax;
        }
        mySlider.value = HealthEnemy; // приравнивает ползунок здоровья к здоровью врага
        if (HealthEnemy <= 0)
        {
            myImage.enabled = false; // ползунок будет пустым если здоровье врага равно 0
        }
        else
        {
            myImage.enabled = true; //ползунок будет заполненым если здоровье врага больше 0
        }

        distance = Vector3.Distance(target.position, transform.position); // к переменной distance приравнивается Vector3-отвечает за координаты объекта
        //target.position - координаты игрока transform.position - координаты врага

        if (HealthEnemy > 0)//если здоровье врага больше 0 то
        {


            if (distance > 10 & transform.position != parking.position)//если дистанция больше 10 и координаты врага не равняются его парковке то он идёт на неё
            {
                myAgent.enabled = true; //активирует врагу возможность ходить
                myAgent.SetDestination(parking.position); // показывает координаты парковки
                myAnimator.SetBool("IdleBool", false); // Выключает анимацию покоя
                myAnimator.SetBool("RunBool", true);// Включает анимацию бега
                myAnimator.SetBool("AttackBool", false); // Выключает анимацию атаки
                myAnimator.SetBool("DeathBool", false); // Выключает анимацию смерти
            }

            if (distance > 10 & transform.position == parking.position) // если дистанция больше 10 и координаты врага равны парковке то он стоит
            {
                transform.LookAt(target.position); //враг поворачивается к игроку
                myAgent.enabled = false; // отключает врагу возможность ходить
                myAnimator.SetBool("IdleBool", true); // Включает анимацию покоя
                myAnimator.SetBool("RunBool", false); // Выключает анимацию бега
                myAnimator.SetBool("DeathBool", false); // Выключает анимацию смерти
            }


            if (distance <= 10 & distance > 2.4f) // если дистанция меньше или равна 10 но больше 2f то враг идёт к игроку
            {

                myAgent.enabled = true; // Включает возможность врагу ходить
                myAgent.SetDestination(target.position); // Показывает координаты игрока
                myAnimator.SetBool("IdleBool", false); // Выключает анимацию покоя
                myAnimator.SetBool("RunBool", true); // Включает анимацию бега
                myAnimator.SetBool("AttackBool", false); // Выключает анимацию атаки
                myAnimator.SetBool("DeathBool", false); // Выключает анимацию смерти
            }
            if (distance <= 1.8f)
            {
                Vector3 lookAt = target.position; //поворачивает врага к игроку
                lookAt.y = transform.position.y; // закрепляет по y 
                transform.LookAt(lookAt); // координаты поворота
                myAgent.enabled = false; // Отключает возможность ходить для врага
                myAnimator.SetBool("AttackBool", true); // Включает анимацию атаки
                myAnimator.SetBool("RunBool", false); // Отключает анимацию бега
                myAnimator.SetBool("DeathBool", false); // Отключает анимацию смерти
            }

        }
        if (HealthEnemy <= 0) // если здоровье врага меньше или равно 0 
        {

            myAgent.enabled = false; // Отключает врагу возможность ходить
            myAnimator.SetBool("IdleBool", false); // Отключить анимацию покоя
            myAnimator.SetBool("AttackBool", false); // Отключить анимацию атаки
            myAnimator.SetBool("RunBool", false); // Отключить анимацию бега

            myAnimator.SetTrigger("DeathTrigger"); // Включить анимацию смерти



            Destroy(gameObject, 3f); // Удалить врага с задержкой в 3 секунды

            if (HealthEnemy <= 0 && isdead == false) // Проверяет здорье врага 
            {
                isdead = true;
                Spawn.Qestenemycount += 1;
                
                Exp.Expirience += Enemyexp; // добавляет опыт к персонажу
                Exp.HeroMoney += moneydrop; // добавляет деньги к персонажу

            }

        }

    }

}

