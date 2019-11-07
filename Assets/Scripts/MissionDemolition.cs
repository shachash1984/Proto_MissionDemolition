using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}
public class MissionDemolition : MonoBehaviour {

    static public MissionDemolition S;


    public GameObject[] castles;
    public Text gtLevel;
    public Text gtScore;
    public Text gtShotsLeft;    
    public Vector3 castlePos;
    public int Shots;
    

    public bool _________________________;

    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Slingshot";
	
	void Start () {
        S = this;
        level = 0;
        levelMax = castles.Length;
        StartLevel();
	}
	
    void StartLevel()
    {
        
        if(castle != null)
        {
            Destroy(castle);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        castle = Instantiate(castles[level]) as GameObject;
        castle.transform.position = castlePos;
        shotsTaken = 0;


        SwitchView("Both");
        ProjectileLine.S.Clear();

        Goal.goalMet = false;
        Shots = 3;
        if (Score.S == null)
        {
            Score.S = FindObjectOfType<Score>();
            Score.S.score = 0;
        }
            
        ShowGT();

        mode = GameMode.playing;
    }
	
	void ShowGT()
    {
        gtLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        gtShotsLeft.text = "Shots Left: " + (Shots - shotsTaken);
    }

    void Update()
    {
        ShowGT();

        if (mode == GameMode.playing && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            SwitchView("Both");     
            Invoke("NextLevel", 2f);   
        }
        else if(mode == GameMode.playing && (Shots - shotsTaken == 0))
        {
            if(FollowCam.S.poi == null)
                Invoke("StartLevel", 2f);
        }
    }

    void NextLevel()
    {
        level++;
        if(level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }

    void OnGUI()
    {
        Rect buttonRect = new Rect((Screen.width / 2) - 40, 10, 100, 24);
        switch (showing)
        {
            case "Slingshot":                
                if (GUI.Button(buttonRect, "Show Castle"))
                {
                    SwitchView("Castle");                    
                }
                break;
            case "Castle":
                
                if (GUI.Button(buttonRect, "Show Both"))
                {
                    SwitchView("Both");                    
                }
                break;

            case "Both":
                if(GUI.Button(buttonRect, "Show Slingshot"))
                {                    
                    SwitchView("Slingshot");                    
                }
                break;
        }
    }

    static public void SwitchView(string eView)
    {
        S.showing = eView;
        switch (S.showing)
        {
            case "Slingshot":
                FollowCam.S.poi = null;                
                break;

            case "Castle":
                FollowCam.S.poi = S.castle;
                    break;

            case "Both":
                FollowCam.S.poi = GameObject.Find("ViewBoth");
                
                break;
        }
    }

    public static void ShotFired()
    {
        S.shotsTaken++;
    }
}
