using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    void Start()
    {
        Invoke("InitScore", 1f);
    }

    void OnCollisionEnter(Collision collision)
    {        
        if(MissionDemolition.S.mode == GameMode.playing)  
            Score.S.score += 10;
    }
	
    void InitScore()
    {
        if (Score.S == null)
        {
            Score.S = FindObjectOfType<Score>();
        }
    }
}
