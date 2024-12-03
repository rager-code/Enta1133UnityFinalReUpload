using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealthEnemy = 200;
    public int currentHealthEnemy;
    public bool enemiesDefeated = false;
    public int howManyEnemiesAreDefeated = 0;
    public int howManyTimesPressed = 0;

    public PlayerHealth playerHealth;

    public GameObject HealthBarDeathEnemy;
    public GameObject EnemySprite;

    
    public Health healthBarEnemy;

    public bool KeyCodePressedOnce = true;
    //public GameObject HealthPotion; // new
    

    private void Start()
    {
        currentHealthEnemy = maxHealthEnemy;
        healthBarEnemy.SetMaxHealth(maxHealthEnemy);

        
        //Instantiate(healthBarEnemy); // new
    }
    public void OnTriggerStay(Collider otherObject)
    {
        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            howManyTimesPressed++;
            TakeDamage(1);
            TimesPressedCheck();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {

            TakeDamage(2);
            KeyCodePressedOnce = false;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {

            TakeDamage(3);
            KeyCodePressedOnce = false;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {

            TakeDamage(4);
            KeyCodePressedOnce = false;
        }
        

        


        if (currentHealthEnemy <= 0)
        {
            Debug.Log("RIP");

            
            enemiesDefeated = true;
            EnemySprite.SetActive(false);
            //HealthBarDeathEnemy.SetActive(false);
            EnemiesDefeatedCheck();
            WinCheck();

            //Object.Destroy(EnemySprite);

            //UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScene");

        }

        if (Input.GetKeyUp(KeyCode.K)) //new
        {
            TakeDamage(-20); //new

        }// new
        


        //HealthPotion.SetActive(false); //new
        /*
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            TakeDamage(-20);

        }
        */

    }
    public void SetMaxHP()
    {


        currentHealthEnemy = 200;


    }
    public void Update()
    {
        if (currentHealthEnemy >= 200)
        {
            SetMaxHP();
        }













    }
    void TakeDamage(int damage)
    {
        currentHealthEnemy -= damage;

        healthBarEnemy.SetHealth(currentHealthEnemy);
    }
    public void EnemiesDefeatedCheck()
    {
        if (enemiesDefeated == true)
        {
            howManyEnemiesAreDefeated++;

        }
       
    }
    public void WinCheck()
    {
        if (howManyEnemiesAreDefeated == 8)
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
        }

    }
    public void TimesPressedCheck()
    {
        if (howManyTimesPressed == 1)
        {
            KeyCodePressedOnce = false;
            
        }

    }
}
