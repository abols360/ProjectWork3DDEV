using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public static class GameCursor{
        public static void EnableCur(bool flag){

            Cursor.visible = flag;
            Cursor.lockState = flag ? CursorLockMode.None : CursorLockMode.Confined;
        }
    }
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] internal InputActionAsset actions;
    Hero _hero;

    bool isChangingScene = false;

    
    


    public Hero Hero
    {
        get
        {
            if(_hero == null)
            {
                _hero = FindObjectOfType<Hero>();
            }
            return _hero;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Hero.OnDied += OnHeroDied;
        GameCursor.EnableCur(false);
    }

    private void Update() {
        if(Keyboard.current.escapeKey.wasPressedThisFrame){
            LoadMainMenu();

        }
    }

    void LoadMainMenu(){
        
        if(isChangingScene)return;
        
        isChangingScene = true;
        Scenes.LoadScene(Scenes.Menu);
        //Scenes.Loa


    }
    private void OnHeroDied()
    {
        Debug.Log("HERO IS DEAD......RestartGame");
       StartCoroutine(RestartSceneRoutine());
    }
  //lauj speli sakt no sakuma pec trim sekundem bet build settingos tas vel tas japievieno
   IEnumerator RestartSceneRoutine()
   {
       yield return new WaitForSeconds(3f);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }


    

}
