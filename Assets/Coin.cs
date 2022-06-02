using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://assetstore.unity.com/packages/2d/environments/free-game-items-131764#description mos ar so nomainīt
// padarit spidigus coinus
public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource _audioSource;
    //public AudioClip coin;
    
    void Start()
    {
        
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other) {
        
       // if (other.name == "Hero"){ //japartaisa, lai nemekle pec string!!! unity basics lekcijā
           if (GameObject.FindObjectOfType<Coin>()){
            other.GetComponent<Hero>().points++;
           // CollectSound();
           //AudioSource.PlayClipAtPoint(coin, transform.position, 0.5f);
           _audioSource.PlayOneShot(_audioSource.clip);
           
            

            RemoveCoin(); //ja ir destroy, tad neskan
        }
    }
    private void RemoveCoin(){
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 4f);
    }   
    // private void CollectSound()
    // {
    //     _audioSource.Play();
    //     Debug.Log("ss");
    // }
}
