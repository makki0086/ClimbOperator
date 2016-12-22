﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : BaseButtonController
{
    
    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected override void OnClick(string ObjectName)
    {
        switch (ObjectName)
        {
            case "MissionMode_Button":
                Debug.Log("aa");
                break;
            case "EndlessMode_Button":
                Debug.Log("bb");
                SceneManager.LoadScene("SceneO^hara");
                break;
            case "BackTitle_Button":
                SceneManager.LoadScene("Title");
                break;
            default:
                break;
        }
       // base.OnClick(ObjectName);
       //if("".Equals(ObjectName))
       // {

       // }

    }
}
