using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        Debug.Log("CLICK");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }



    public void LoadScene(string GameLevel1)
    {
        SceneManager.LoadScene(GameLevel1);
    }
    
}
