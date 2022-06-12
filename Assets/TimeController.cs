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
        bestTime.text = PlayerPrefs.GetString("bestTime", "05:00.01").ToString();

        
    }
    public void BeginTime(){
        timerGoing = true;
        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
    }
    public void EndTimer(){
        timerGoing = false;
        //Debug.Log(timeCounter.text + "ASDAS");
        String[] splitNewTime = timeCounter.text.Split(char.Parse("."));
        
        String NewT = splitNewTime[0].Replace(":", ".");
        String[] splitOldTime = bestTime.text.Split(char.Parse("."));
        String OldT = splitOldTime[0].Replace(":", ".");
        float OldTime= float.Parse(OldT);
        float newTime= float.Parse(NewT);
       // Debug.Log(OldTime+" old1");
       // Debug.Log(newTime+" new1");


        if(newTime < OldTime){ 
            PlayerPrefs.SetString("bestTime", timeCounter.text);
        }else if (newTime == OldTime){
            if (float.Parse(splitNewTime[1]) < float.Parse(splitOldTime[1]))
            {
                 PlayerPrefs.SetString("bestTime", timeCounter.text);
            }

           // Debug.Log("Vēl jātrenējas");
        }
        

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
