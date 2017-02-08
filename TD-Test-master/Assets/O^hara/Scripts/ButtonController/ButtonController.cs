using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class ButtonController : BaseButtonController
{
    [SerializeField]
    private GameOver gameover; 
   
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
            case "StorageBattery_Button":
                RobotTypeManager.ChangeRobotType(RobotTypeManager.RobotType.StorageBattery);
                SceneManager.LoadScene("SceneO^hara");
                break;
            case "DryBattery_Button":
                RobotTypeManager.ChangeRobotType(RobotTypeManager.RobotType.DryBattery);
                SceneManager.LoadScene("SceneO^hara");
                break;
            case "Start_Button":
                Debug.Log("aa");
              //  SceneManager.LoadScene("SceneO^hara");
                SceneManager.LoadScene("RobotTypeSelect");
                break;

            case "Button":
                Debug.Log("ww");
                break;

            case "Title":
                SceneManager.LoadScene("Title");
                break;
            case "Restart":
                SceneManager.LoadScene("SceneO^hara");
                break;
            case "Skip":
                gameover.Skip();
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
