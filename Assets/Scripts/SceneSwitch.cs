using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
 
public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
    public void ToWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
        DontDestroyOnLoad(GameObject.Find("ScoreManager"));
    }
    
    public void ToAsteroids()
    {
        SceneManager.LoadScene("AsteroidScreen");
    }
    public void ToDieScreen()
    {
        SceneManager.LoadScene("DeathScreen");
        DontDestroyOnLoad(GameObject.Find("ScoreManager"));
    }
        public void ToCreditsScreen()
    {
        SceneManager.LoadScene("CreditsScreen");
        DontDestroyOnLoad(GameObject.Find("Music"));
    }
         public void ToControlsScreen()
    {
        SceneManager.LoadScene("ControlsScreen");
        DontDestroyOnLoad(GameObject.Find("Music"));
    }
         public void ToGame()
    {
        SceneManager.LoadScene("GameScreen");
        Destroy(GameObject.Find("Music"));
    }
         public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }


}
