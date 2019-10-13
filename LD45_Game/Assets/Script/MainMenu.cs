using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }

   public void gotoTutorial(){
       SceneManager.LoadScene("Tutorial");
   }

   public void gotoMainMenu(){
       Debug.Log("menu");
       SceneManager.LoadScene("Menu");
   }
}
