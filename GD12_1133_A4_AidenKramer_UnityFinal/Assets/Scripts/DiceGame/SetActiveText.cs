using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveText : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject GreatSwordActivate;
   // public GameObject AxeSwordActivate;
    public GameObject ShortSwordActivate;
    public GameObject LongSwordActivate;
    public GameObject HealthPotionActivate;
    public bool TreasureRoomEntered = false;

    void Start()
    {
        GreatSwordActivate.SetActive(false);
        ShortSwordActivate.SetActive(false);
        LongSwordActivate.SetActive(false);
        HealthPotionActivate.SetActive(false);
    }
    public void OnTriggerEnter(Collider yes)
    {
       //TreasureRoomEntered = true;
    }
    public void OnTriggerStay(Collider yes)
    {
        TreasureRoomEntered = true;
        Debug.Log("TreasureEnteredBool");


    }
    private void Update()
    {
       //if (TreasureRoomEntered == true)
       {
            
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("TresureWorkInv----------------------");
                SetActiveINVTEXT();


            }

       }
        
        
       

        if (Input.GetKeyDown(KeyCode.R))
        {
            SetActiveINVTEXTs();

        }
    }


    public void SetActiveINVTEXT()
    {
            //List<string> mylist = new List<string>(); 
            //myList.Add("GreatSword");
            //myList.Add("ShortSword");
            //myList.Add("LongSword)");
            //myList.Add("Potion");
        
        //int randomIndex = Random.Range(0, mylist.Count);
        
        
        
        //Random.Range(0, 3);

            Debug.Log("SetActiveInvWorking__________________");

            GreatSwordActivate.SetActive(true);
            ShortSwordActivate.SetActive(true);
            LongSwordActivate.SetActive(true);
            HealthPotionActivate.SetActive(true);


        
           

        //UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            
        
    }
    public void SetActiveINVTEXTs()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        GreatSwordActivate.SetActive(false);
    }
}
