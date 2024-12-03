using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemMenu : MonoBehaviour
{
    [SerializeField] public GreatSowrdButton GreatSwordButton;
    [SerializeField] public GreatSowrdButton AxeButton;
    [SerializeField] public GreatSowrdButton LongSwordButton;
    [SerializeField] public GreatSowrdButton ShortSwordButton;
    [SerializeField] public GreatSowrdButton HealthPotionButton;

    
    //[SerializeField] private GreatSowrdButton LongSwordButton;


    
    

    public bool isItemPopUpClosed = false;

    public GameObject itemMenu;
   
    public void Start()
    {
        itemMenu.SetActive(false);
        Debug.Log("StartUI2");
        
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Pressed2");
            if (isItemPopUpClosed)
            {
                ItemPopUpClosed();

            }
            else
            {
                ItemPopUpOpen();


            }

        }


    }
    public void ItemPopUpOpen()
    {

        itemMenu.SetActive(true);

        isItemPopUpClosed = true;

        
    }

    public void ItemPopUpClosed()
    {

        itemMenu.SetActive(false);

        isItemPopUpClosed = false;

       
    }
    public void SetPlayerReferenceGS(PlayerController ps)
    {
        GreatSwordButton.SetPlayerReferenceGS(ps);

    }
    public void SetPlayerReferenceAxe(PlayerController ps)
    {
        AxeButton.SetPlayerReferenceAxe(ps);

    }
    public void SetPlayerReferenceShortSword(PlayerController ps)
    {
        ShortSwordButton.SetPlayerReferenceShortSword(ps);

    }
    public void SetPlayerReferenceLongSword(PlayerController ps)
    {
        LongSwordButton.SetPlayerReferenceLongSword(ps);

    }
    public void SetPlayerReferenceHealthPotion(PlayerController ps)
    {
        HealthPotionButton.SetPlayerReferenceHealthPotion(ps);

    }
    public void SetActives()
    {
        


    }
}
