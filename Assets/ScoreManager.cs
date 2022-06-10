using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    // Start is called before the first frame update
    public Text scoreTxt;
    public int points = 0;
    //int score = 0;

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        scoreTxt.text = points.ToString() + " POINTS";
    }

    // Update is called once per frame
    

    public void AddPoint(){

         points +=1;
         scoreTxt.text = points.ToString() + " POINTS";

    }
}
