using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    Hero _hero;

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
    }

    private void OnHeroDied()
    {
        Debug.Log("HERO IS DEAD......RestartGame");
       StartCoroutine(RestartSceneRoutine());
    }
  //lauj speli sakt no sakuma pec trim sekundem bet build settingos tas vel tas japievieno
   IEnumerator RestartSceneRoutine()
   {
       yield return new WaitForSeconds(8f);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
