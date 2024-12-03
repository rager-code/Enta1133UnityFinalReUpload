using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 200;
    public int currentHealth;
    public float timer = 0f;
    public bool timerstart = false;

    public bool RoomSearched = false;

    [SerializeField] private EnemyHealth EnemyHealth_Script;

    public Health healthBar;

    public GameObject HealthPotion; // new

    public GameObject EnemyOnDeathTimerStop;
    
    public int NumberOfTimesRoomSearched = 0;
    public void SetMaxHP()
    {

        currentHealth = 200;
        currentHealth = maxHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


    }
    public void OnTriggerEnter(Collider otherObject)
    {
        // timerstart = true;
        //timer = 1f;
        //RoomSearched = true;


        //NumberOfTimesRoomSearched++;
        TimerChecker();
        //if (EnemyHealth_Script.currentHealthEnemy  0 )
        //{
            
        //}
        
        //TimerChecker();






    }
    public void OnTriggerStay(Collider otherObject)
    {

        //RoomSearched = true;

        //TimerStarting();
        //Debug.Log("TimerStarting");

        //TakeDamage(1);





        if (currentHealth < 0)
        {
            Debug.Log("RIP");
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScene");

            //currentHealth = maxHealth; // new

            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            timerstart = false;
        }
        //if (currentHealthEnemy <= 0)
        //{
            //timerstart = false;

        //}





    }
    public void OnTriggerExit(Collider other)
    {
        timerstart = false;
        NumberOfTimesRoomSearched++;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {


            TakeDamage(1);

        }
        if (currentHealth <= 0)
        {
            Debug.Log("RIP");
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScene");
            timerstart = false;
        }

        if (Input.GetKeyUp(KeyCode.Alpha5)) //new
        {
            TakeDamage(-20); //new

        }// new

        // CurrentHealth
        if (currentHealth >= 200)
        {
            SetMaxHP();
        }


         

        //Change to enemy health
        //if (currentHealth == 200)
        //{
        //TakeDamage(20);

        //}
        //if (currentHealth == 100)
        //{
        //TakeDamage(30);

        //}
        //if (currentHealth == 25)
        //{
        //TakeDamage(60);

        //}
        //HealthPotion.SetActive(false); //new
        /*
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            TakeDamage(-20);

        }
        */
        if (timerstart == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                TakeDamage(1);
                if (timer >= 0)
                {
                    timer = 0;
                }
            }

        }

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    public void HealthPotionWorking()
    {


    }
    public void EndTimer()
    {
        //damage Enemy deals
        TakeDamage(15);
        if (timer >= 0)
        {
            timer = 0;
        }
    }
    public void TimerStarting()
    {
            timerstart = true;
            timer = 1;
    }
    public void TimerChecker()
    { 
        if (NumberOfTimesRoomSearched <= 0)
        {
            timerstart = true;
        }
        else if (NumberOfTimesRoomSearched <= 3)
        {
            timerstart = false;
        }
    }
}
