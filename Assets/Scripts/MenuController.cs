using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Gera um indice para as cenas que estao no buiding settings
    }
    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Saindo");
    }
    public void GoConfigurations ()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);  
    }
    public void GoCredits ()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);  
    }
    public void GoBackMenu ()
    {
      SceneManager.LoadScene("Menu");
    }

}
