using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://assetstore.unity.com/packages/2d/environments/free-game-items-131764#description mos ar so nomainīt
// padarit spidigus coinus
public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other) {
        
        if (other.name == "Hero"){ //japartaisa, lai nemekle pec string!!! unity basics lekcijā
            other.GetComponent<Hero>().points++;


            Destroy(gameObject); //
        }
    }
}
