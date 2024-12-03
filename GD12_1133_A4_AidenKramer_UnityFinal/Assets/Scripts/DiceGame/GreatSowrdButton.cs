using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreatSowrdButton : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController PlayerScript;

    public void SetPlayerReferenceGS(PlayerController ps)
    {
        PlayerScript = ps;

    }
    public void SetPlayerReferenceAxe(PlayerController ps)
    {
        PlayerScript = ps;

    }
    public void SetPlayerReferenceShortSword(PlayerController ps)
    {
        PlayerScript = ps;

    }
    public void SetPlayerReferenceLongSword(PlayerController ps)
    {
        PlayerScript = ps;

    }
    public void SetPlayerReferenceHealthPotion(PlayerController ps)
    {
        PlayerScript = ps;

    }
    public void Start()
    {
        
    }
    public void ButtonsStartGame3()
    {
        //SceneManager.LoadScene("SampleScene");

        //gameObject.SetActive(false);
        Debug.Log("W");
        PlayerScript.GreatSwordOnActive();


    }
    public void SwordACtive()
    {
        //SceneManager.LoadScene("SampleScene");

        
        Debug.Log("L");

        
    }





    public void ButtonsStartPlayerAxe()
    {
        PlayerScript.AxeOnActive();


    }
    public void ButtonsStartPlayerShortSword()
    {
        PlayerScript.ShortSwordOnActive();


    }
    public void ButtonsStartPlayerLongSword()
    {
        PlayerScript.LongSwordOnActive();


    }
    public void ButtonsStartPlayerHealthPotion()
    {
        PlayerScript.HealthPotionOnActive();


    }

}
