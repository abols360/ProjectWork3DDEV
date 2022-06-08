using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


 public static class Scenes{

        public const string Menu = "Menu";
        public const string Game = "Game";
        public const string Rules = "Rules";
        public const string YouLost = "YouLost";
         public const string YouWin = "YouWin";
      



        public static void LoadScene(string sceneName){
            SceneManager.LoadScene(sceneName);
        }
    }
public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
   
   private void Start() {
       GameCursor.EnableCur(true);
   }
   
    public void PlayGame(){
        Debug.Log("Play");
        Scenes.LoadScene(Scenes.Game);

    }
    public void GameRules(){
        Debug.Log("Rules");
        Scenes.LoadScene(Scenes.Rules);
    }
      public void GameMenu(){
        Debug.Log("Menu");
        Scenes.LoadScene(Scenes.Menu);
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
     public void LostGame(){
        Debug.Log("YouLost");
        Scenes.LoadScene(Scenes.YouLost);
    }
    public void WinGame(){
        Debug.Log("YouWin");
        Scenes.LoadScene(Scenes.YouWin);
    }


    
}
