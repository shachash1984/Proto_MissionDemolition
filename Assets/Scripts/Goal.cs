using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    static public bool goalMet = false;

    GameObject goal;
    Color c;

    void Awake()
    {
        goal = this.gameObject;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            Goal.goalMet = true;            
            ChangeAlpha();            
        }
    }

    void ChangeAlpha()
    {
        c = goal.GetComponent<Renderer>().material.color;
        c.a = 1;
        goal.GetComponent<Renderer>().material.color = c;
    }
    
}
