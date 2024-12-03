using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void ButtonStartGame()
    {
        //SceneManager.LoadScene("SampleScene");
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    
}
