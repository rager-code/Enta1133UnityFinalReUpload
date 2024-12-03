
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatRoom : RoomBase
{

   GameObject PlayerCombat;
   [SerializeField] private EnemyHealth EnemyHealth_Script;
   [SerializeField] private PlayerHealth PlayerHealth_Script;
   [SerializeField] private Health Health_Script;

    // Start is called before the first frame update
    public void Start()
    {
        
    }
    public void Update()
    {
       
    }
    public void OnTriggerEnter(Collider collider)
    {
        
        Debug.Log("IN ROOM Comabt======");
        //EnemyHealth_Script.
        
    }
    public void OnTriggerStay(Collider collider)
    {
        //PlayerHealth_Script.timerstart = true;
        //Debug.Log("IN ROOM stay Combat=======");
    }
    public void OnTriggerExit(Collider collider)
    {
        //PlayerHealth_Script.timerstart = false;
        Debug.Log("out ROOM Combat======");
    }
}
