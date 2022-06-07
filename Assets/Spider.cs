using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : Character
{

    [SerializeField] float closeEnoughDistance = 4f;

    //[SerializeField] float farEnoughDistance = 5f;

    [SerializeField] float damagePerSecond = 20f;
    [SerializeField] Transform sightOrgin;
    [SerializeField] LayerMask sightMask = ~0;

    Animator _animator;

    NavMeshAgent _navMeshAgent;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioSource _spiderWalk;
    //AudioSource _spiderStep;

    float attackCount = 0; 

 public Vector3 HeroPosition => GameManager.instance.Hero.transform.position + Vector3.up * 0.5f;
    // bool isIdle = false;
    // bool isAttacking = false;

      enum State
    {
        None = 0,
        Idle = 1, 
        Following = 2,
        Attacking = 3
    }

    State _state = State.None;

    State CurrentState
    {
        get => _state;
        set
        {
            if (_state != value)
            {
                _state = value;
                UpdateState();
            }
        }
    }
 
 

    protected override void Start()
    {
        base.Start();
       _animator = GetComponentInChildren<Animator>();
       _navMeshAgent = GetComponent<NavMeshAgent>();
      // _audioSource = GetComponent<AudioSource>();
       CurrentState = State.Idle;
      //Debug.Log("StartTest");
    }

    private void Update()
    {
         Vector3 heroPosition = GameManager.instance.Hero.transform.position;
        float distanceToHero = Vector3.Distance(transform.position, heroPosition);

        switch(CurrentState){



            case State.Idle:
            if(CanSeePlayer()){
                CurrentState = State.Following;
                //Debug.Log(health); 
            }
            break;
            
            case State.Following:
            //Debug.Log("fs");
            //_spiderWalk.Play();
            ///break;


            case State.Attacking:
 
            if (distanceToHero < closeEnoughDistance)
            {
                _navMeshAgent.velocity = Vector3.zero;
                // GameManager.instance.Hero.AddDamage(Time.deltaTime * damagePerSecond);
               
                CurrentState = State.Attacking;
              //  Debug.Log(health);
           if(attackCount >= 5 ){
                    CurrentState = State.Idle;
                    Debug.Log("player is dead stop attack");
                }
            }
            else
            {
              
                CurrentState = State.Following;
            }
            //  if(distanceToHero > farEnoughDistance){
            //         CurrentState = State.Idle;
            //         Debug.Log("Far distance");
            //     }
             if(!CanSeePlayer()){
                CurrentState = State.Idle;
                //Debug.Log(health); 
            }
            break;
        }

       

        switch(CurrentState){

            case State.Following:
            _navMeshAgent.SetDestination(heroPosition);
            break;
        }
    }
    void UpdateState() {
        Debug.Log("UpdateState: " + CurrentState);
        if (CurrentState == State.Following){
            _spiderWalk.Play();
        }else{
            _spiderWalk.mute = !_spiderWalk.mute;
        }
        
    //     bool pos = CurrentState == State.Attacking;
    //     bool isAttacing = _animator.GetBool("isAttacking");
    //     if (pos != isAttacing) _animator.SetBool("isAttacking", pos);

        int animState = _animator.GetInteger("state");
        if ((int)CurrentState != animState) _animator.SetInteger("state", (int)CurrentState);
    // }

    // void UpdateAttackAnim(bool pos){
    //     bool isAttacking = _animator.GetBool("isAttacking");
    //     if (pos != isAttacking){
    //         _animator.SetBool("isAttacking", pos);
    //     }
        
     }
    public void Bite(){
          if (CurrentState == State.Attacking){
              GameManager.instance.Hero.AddDamage(damagePerSecond);
               _audioSource.Play();  
                Debug.Log(health);
                attackCount ++;
          }  
    }
    // public override void AddDamage(float damage)
    // {
    //     base.AddDamage(damage);
    //    // if(health <= 0 ){
    //         Debug.Log(health);
            
    //    // } 
    //     // if (!isDead) {
    //     // _animator.SetTrigger("GetDamage");
    //     // }
       
    // }

    bool CanSeePlayer(){
        Vector3 heroPosition = HeroPosition;
        bool canSee = false;
        Vector3 hitPos = heroPosition;

        Vector3 dir = (heroPosition - sightOrgin.position).normalized;

        if (Physics.Raycast(sightOrgin.position, dir, out RaycastHit hit, 30f, sightMask))
        {
             
            if (hit.transform.gameObject.CompareTag("Player")) canSee = true;

            hitPos = hit.point;

            Debug.DrawLine(
                sightOrgin.position,
                hit.point,
                canSee ? Color.green : Color.yellow
            );
             
        }
        else
        {
            Debug.DrawRay(sightOrgin.position, dir, Color.red);
            canSee = false;
        }
        return canSee;
        
       
        }
    
 
}
