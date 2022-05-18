using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHero : MonoBehaviour
{

    float health = 100;
    bool isDead = false;
    
    
    void AddDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

    }
  
}
