using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Image HealthBar;

    // Update is called once per frame
    public Slider slider;


    [SerializeField] private Camera pCamera;
    [SerializeField] private Transform target;

    public void SetMaxHealth(int health)
    {

        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        
        slider.value = health;
    }
    //public void OnHealthChange(float currentHealth, float maxhealth)
    //{
    //HealthBar.fillAmount = currentHealth / maxhealth;
    //}
    //private void Update()
    //{
        //transform.rotation = camera.transform.rotation;
    //}
}
