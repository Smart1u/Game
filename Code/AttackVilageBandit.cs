using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using UnityEngine.UI; 
public class AttackVilageBandit : MonoBehaviour
{
    public float timerespawn = 15f;
    private NavMeshAgent myAgent; 
    private Animator myAnimator;
    private float distance; 
    private float distance2;
    public Transform target;
    public Transform target2; 
    public int HealthEnemy = 100; 
    public int HealthEnemyMax = 100; 
    public Slider mySlider; 
    public Image myImage; 
    public GameObject HealthBarUI; 
    public int Enemyexp = 50; 
    private CharacterController myControl;
    public Health_Hero Exp; 
    public bool isdead = false;
    public QestSpawn Spawn;
    public Qest q;
    public QestVilage qest;
    public int moneydrop = 25;
    void Start() 
    {
        HealthEnemy = HealthEnemyMax;
        mySlider.value = HealthEnemy; 
        myAgent = GetComponent<NavMeshAgent>(); 
        myAnimator = GetComponent<Animator>(); 
        myControl = GetComponent<CharacterController>(); 
    }
    void Update() 
    {
        if (HealthEnemy < HealthEnemyMax) 
        {
            HealthBarUI.SetActive(true); 
        }
        if (HealthEnemy > HealthEnemyMax) 
        {
            HealthEnemy = HealthEnemyMax;
        }
        mySlider.value = HealthEnemy; 
        if (HealthEnemy <= 0)
        {
            myImage.enabled = false; 
        }
        else
        {
            myImage.enabled = true; 
        }
        distance = Vector3.Distance(target.position, transform.position);
        distance2 = Vector3.Distance(target2.position, transform.position); 
        //target.position - координаты игрока    transform.position - координаты врага
        if (HealthEnemy > 0)
        {
            if (distance > 10 & transform.position != target2.position) // бег
            {
                myAgent.enabled = true; 
                myAgent.SetDestination(target2.position);
                myAnimator.SetBool("IdleBool", false); 
                myAnimator.SetBool("RunBool", true); 
                myAnimator.SetBool("DeathBool", false); 
            }

            if (distance > 10 & distance2 >2.4f) // бег
            {
                myAgent.enabled = true; 
                myAnimator.SetBool("AttackBool", false); 
                myAnimator.SetBool("RunBool", true); 
                myAnimator.SetBool("DeathBool", false); 
            }
            if (distance > 10 & distance2 <= 1.8f) // атака
            {
                Vector3 lookAt = target2.position; 
                lookAt.y = transform.position.y; 
                transform.LookAt(lookAt); 
                myAgent.enabled = false; 
                myAnimator.SetBool("AttackBool", true); 
                myAnimator.SetBool("RunBool", false); 
                myAnimator.SetBool("DeathBool", false); 
            }
            if (distance <= 10 & distance > 2.4f) // бег
            {
                myAgent.enabled = true; 
                myAgent.SetDestination(target.position); 
                myAnimator.SetBool("IdleBool", false); 
                myAnimator.SetBool("RunBool", true); 
                myAnimator.SetBool("AttackBool", false); 
                myAnimator.SetBool("DeathBool", false); 
            }
            if (distance <= 1.8f)// атака
            {
                Vector3 lookAt = target.position; 
                lookAt.y = transform.position.y; 
                transform.LookAt(lookAt); 
                myAgent.enabled = false; 
                myAnimator.SetBool("AttackBool", true); 
                myAnimator.SetBool("RunBool", false);
                myAnimator.SetBool("DeathBool", false); 
            }
        }
        if (HealthEnemy <= 0) // смерть
        {
            myAgent.enabled = false; 
            myAnimator.SetBool("IdleBool", false); 
            myAnimator.SetBool("AttackBool", false); 
            myAnimator.SetBool("RunBool", false); 
            myAnimator.SetTrigger("DeathTrigger"); 
            Destroy(gameObject, 3f); // Удалить врага с задержкой в 3 секунды

            if (HealthEnemy <= 0 && isdead == false) 
            {
                isdead = true;
                q.enemydead +=1;
                qest.enemydead += 1;
                Exp.Expirience += Enemyexp; 
                Exp.HeroMoney += moneydrop; 

            }

        }

    }
}
