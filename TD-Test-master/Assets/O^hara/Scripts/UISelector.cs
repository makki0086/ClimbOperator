using UnityEngine;
using System.Collections;

public class UISelector : MonoBehaviour {

    private RobotTypeManager.RobotType type;

    [SerializeField]
    private GameObject[] BatteryUI;

    

	// Use this for initialization
	void Start () {
        RobotTypeManager.ChangeRobotType(RobotTypeManager.RobotType.DryBattery);

        switch (type = RobotTypeManager.getRobotType())
        {
            case RobotTypeManager.RobotType.StorageBattery:
                BatteryUI[0].SetActive(true);
                BatteryUI[1].SetActive(false);
                break;

            case RobotTypeManager.RobotType.DryBattery:
                BatteryUI[0].SetActive(false);
                BatteryUI[1].SetActive(true);
                break;
        }

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
