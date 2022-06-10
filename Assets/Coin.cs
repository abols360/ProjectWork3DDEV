using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://assetstore.unity.com/packages/2d/environments/free-game-items-131764#description mos ar so nomainīt
// padarit spidigus coinus
public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    // AudioSource _PulseSound;
    // AudioSource _audioSource;
    [SerializeField] AudioSource _pulseSound;
     [SerializeField] AudioSource _collectCoin;
    
    
    //public AudioClip coin;
    
    void Start()
    {
        // _pulseSound = GetComponent<AudioSource>();
        // _collectCoin = GetComponent<AudioSource>();
        // //  _PulseSound = gameObject.AddComponent<AudioSource>();
        // _audioSource = gameObject.AddComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other) {
       // if(other.transform.tag == "Hero"){// jāsalabo
        // if (other.name == other.FindObjectWithTag("Hero")){

        // }

        
       // if (other.name == GameObject.FindObjectOfType<Hero>()){ //japartaisa, lai nemekle pec string!!! unity basics lekcijā
           if (GameObject.FindObjectOfType<Coin>()){
            other.GetComponent<Hero>().points++;
            ScoreManager.instance.AddPoint();
           // Destroy(_PulseSound);
           // CollectSound();
           //AudioSource.PlayClipAtPoint(coin, transform.position, 0.5f);
          // 
           _pulseSound.mute = !_pulseSound.mute;
           _collectCoin.PlayOneShot(_collectCoin.clip);
           
           Debug.Log(_collectCoin);
           
            

            RemoveCoin(); 

            if (other.GetComponent<Hero>().points == 5 ){
                TimeController.instance.EndTimer();
                Debug.Log("You win!!!!!");
                Scenes.LoadScene(Scenes.YouWin);
            }
        }
      //  }
    }
    private void RemoveCoin(){
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<CoinL>()
        Destroy(gameObject, 4f);
    }   
    // private void CollectSound()
    // {
    //     _audioSource.Play();
    //     Debug.Log("ss");
    // }
}
