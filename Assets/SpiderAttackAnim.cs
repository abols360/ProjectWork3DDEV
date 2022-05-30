using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttackAnim : MonoBehaviour
{
    // Start is called before the first frame update
    Spider _spider;
    void Start() {

      _spider = GetComponentInParent<Spider>();  
    }
   void SpiderAttack(){
       _spider.Bite();
   }
}
