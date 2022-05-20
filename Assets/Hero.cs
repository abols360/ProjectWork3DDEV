using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Hero : Character
{


    ThirdPersonController _thirdPersonController;

    private void Start()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
      //  Die();
     //_animator += 
    }


   

   protected override void Die()
    {

        base.Die();

        if (_thirdPersonController)_thirdPersonController.enabled = false;
    }
}
