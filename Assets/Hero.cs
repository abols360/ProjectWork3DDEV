using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class Hero : Character
{

public int points = 0;
// public int curH = 0;
// public int maxH = 100;


    [SerializeField] Slider HealthBar;
    GameHeroController _gameHeroController;
    ThirdPersonController _thirdPersonController;

    Animator _animator;

   // private Animator animator;
    protected override void Start()
    {
        base.Start();
        _gameHeroController = GetComponent<GameHeroController>();
        _animator = GetComponentInChildren<Animator>();
        //health = 100;
     //   curH = maxH; 
        // HealthBar.value = health;
        // HealthBar.maxValue = maxHealth;
        //HealthBar.minValue = 50f;
         //Debug.Log(HealthBar.value + "dsfdsfsdf");
        
      //  Die();
     //_animator += 
    }


   

   protected override void Die()
    {
       // _thirdPersonController.enabled = false;
    
        if(isDead) return;
        _animator.SetTrigger("Die");
        

        if (_gameHeroController)_gameHeroController.enabled = false;
        base.Die();
    }
    public override void AddDamage(float damage)
    {
        base.AddDamage(damage);
     
        Debug.Log(HealthBar.value + "asd");

        if(health <= 0 ){
            Die();
            
        } 
        if (!isDead) {
        _animator.SetTrigger("GetDamage");
        }
       
    }
    protected override void UpdateHealth(){
        HealthBar.value = HealthValue;
    }

    private void OnGUI() {
        // GUI.Label(new Rect (10, 10, 100, 20), "Score: " + points);
        // GUI.Label(new Rect (50, 0, 100, 50), "health: " + health);

        GUILayout.BeginVertical();

        GUILayout.Label( "Score: " + points);
        
        GUILayout.Label(  "health: " + health);

        GUILayout.EndVertical();



       // GUI.Label(new Rect (50, 0, 100, 50), "health: " + health);
    }
}
