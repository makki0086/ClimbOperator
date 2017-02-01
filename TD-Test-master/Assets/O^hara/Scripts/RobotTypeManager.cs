using UnityEngine;
using System.Collections;

public class RobotTypeManager : MonoBehaviour {
    public enum RobotType
    {
        //!その他
        None,
        //! 蓄電池
        StorageBattery,
        //! 乾電池
        DryBattery
    }

    public static RobotType type = RobotType.None;

    public static RobotType getRobotType()
    {
        return type;
    }
    public static void ChangeRobotType(RobotType _type)
    {
        type = _type;
    }

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
