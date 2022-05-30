using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Hero : Character
{

public int points = 0;


    ThirdPersonController _thirdPersonController;

    Animator _animator;

    protected override void Start()
    {
        base.Start();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _animator = GetComponentInChildren<Animator>();
      //  Die();
     //_animator += 
    }


   

   protected override void Die()
    {

    
        if(isDead) return;
        _animator.SetTrigger("Die");

        if (_thirdPersonController)_thirdPersonController.enabled = false;
        base.Die();
    }
    public override void AddDamage(float damage)
    {
        base.AddDamage(damage);
        if(health <= 0 ) Die();
        if (!isDead) {
        _animator.SetTrigger("GetDamage");
        }
       
    }

    private void OnGUI() {
        GUI.Label(new Rect (10, 10, 100, 20), "Score: " + points);
    }
}
