using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Awake()
    {
        Debug.Log("Just crete awake");
    }
    
    void Start()//work like constructor
    {
        Debug.Log("ss");
    }

    // Update is called once per frame
    void Update()
    {
        
        //fixedUpdate priekš fizikas
    }
}
