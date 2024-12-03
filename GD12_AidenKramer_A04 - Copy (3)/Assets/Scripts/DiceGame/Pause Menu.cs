using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGamePaused = false;

    public GameObject pauseMenu;
    public void Start()
    {
        pauseMenu.SetActive (false);
        Debug.Log("StartUI");
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pressed");
            if (isGamePaused)
            {
                ResumeGame();

            }
            else
            {
                
                PauseGame();
            }
            
        }
        

    }
    public void PauseGame()
    {
        
        pauseMenu.SetActive(true); 
        
        isGamePaused = true;

        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        
        pauseMenu.SetActive(false);
        
        isGamePaused = false;
        
        Time.timeScale = 1f;
    }
    
    
        


    
   
}