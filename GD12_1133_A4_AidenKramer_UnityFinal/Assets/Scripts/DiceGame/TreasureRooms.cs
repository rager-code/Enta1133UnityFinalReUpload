
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class TreasureRooms : RoomBase
{
    public GameObject treasureLoreText;
    public GameObject GreatSword;
    public void Start()
    {
        treasureLoreText.gameObject.SetActive(false);
        GreatSword.SetActive(false);
    }
    public void OnTriggerEnter(Collider otherObject)
    {
       
        Debug.Log("IN ROOM Treasure----");

        //SceneManager.LoadScene("SampleScene");

        OnRoomEntered();

        
        

    }
    public void OnTriggerStay(Collider otherObject)
    {

        //   Debug.Log("IN ROOM stay Treasure----");

        treasureLoreText.gameObject.SetActive(true);
        //    Debug.Log("treasureloreworks!");

         //   GreatSword.SetActive(true);

        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("WORKS________________________----___--");


        }
    }
    public void OnTriggerExit(Collider otherObject)
    {
        treasureLoreText.gameObject.SetActive(false);
        Debug.Log("out ROOM Treasure-----");
        
        GreatSword.SetActive(false);
    }
    public override void OnRoomEntered()
    {
        base.OnRoomEntered();

        GreatSword.SetActive(true);
        Debug.Log("Set WeaponButton3--------------------------");
        //ItemMenu iMenu = FindObjectOfType<ItemMenu>();
        
    }
    private void OnEnable()
    {
        
    }
}
   

