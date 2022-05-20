using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Character
{

    [SerializeField] float closeEnoughDistance = 4f;

    [SerializeField] float damagePerSecond = 20f;

    Animator _animator;

 

    private void Start()
    {
       _animator = GetComponentInChildren<Animator>();
       //CurrentState = State.Idle;
      Debug.Log("StartTest");
    }

    private void Update()
    {
        Vector3 heroPosition = GameManager.instance.Hero.transform.position;
        float distanceToHero = Vector3.Distance(transform.position, heroPosition);

        //   Debug.Log("distance to hero" + distanceToHero);

          if (distanceToHero < closeEnoughDistance)
        {
            GameManager.instance.Hero.AddDamage(Time.deltaTime * damagePerSecond);
            // CurrentState = State.Attacking;
            _animator.SetBool("isAttacking", true);
        }
       else
       {
           _animator.SetBool("isAttacking", false);
       }
    }
 
}
