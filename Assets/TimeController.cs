using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public Text timeCounter;
    public Text bestTime;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;
    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
        bestTime.text = PlayerPrefs.GetString("bestTime", "05:00:01").ToString();

        
    }
    public void BeginTime(){
        timerGoing = true;
        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
    }
    public void EndTimer(){
        timerGoing = false;
        Debug.Log(timeCounter.text + "ASDAS");
        //Debug.Log(float.Parse(timeCounter.text));
        //float newTime= float.Parse(timeCounter.text);
        //float OldTime= float.Parse(bestTime.text);


       // if(newTime < OldTime){ //jāizdomā, kā parveidot divus stringus uz float un salidzīnāt. moš splitot???
            PlayerPrefs.SetString("bestTime", timeCounter.text);
       // }
        

    }

    private IEnumerator UpdateTimer(){

        while(timerGoing){
            elapsedTime+= Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            yield return null;
        }
    }


    // Update is called once per frame
    
}
