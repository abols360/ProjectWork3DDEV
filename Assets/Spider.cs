using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : Character
{

    [SerializeField] float closeEnoughDistance = 4f;

    [SerializeField] float damagePerSecond = 20f;
    [SerializeField] Transform sightOrgin;
    [SerializeField] LayerMask sightMask = ~0;

    Animator _animator;

    NavMeshAgent _navMeshAgent;
    AudioSource _audioSource;

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
       _audioSource = GetComponent<AudioSource>();
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
            }
            break;
            
            case State.Following:
            case State.Attacking:
        
            if (distanceToHero < closeEnoughDistance)
            {
                _navMeshAgent.velocity = Vector3.zero;
                // GameManager.instance.Hero.AddDamage(Time.deltaTime * damagePerSecond);
               
                CurrentState = State.Attacking;
          
            }
            else
            {
                CurrentState = State.Following;
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
               _audioSource.Play(); //SKAN tikai tad, ja ieiet un iezie no uzbrukuma rādiusa. 
                Debug.Log("SOUND");
          }  
    }

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
        }
        return canSee;
        
       
        }
    
 
}
