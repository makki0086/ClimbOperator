using UnityEngine;
using System.Collections;

public class SupportRobot : MonoBehaviour {

    [SerializeField]
    //! 蓄電池のプレハブ
    private GameObject[] m_Storage_Battery_prefab;

    [SerializeField]
    //! 乾電池のプレハブ
    private GameObject[] m_DryBattery_prefab;

    //! ロボットのタイプ
    private RobotTypeManager.RobotType type;
    //!　ロボットの正面座標
    private Vector3 Robot_Forward_Pos;

    private GameObject m_Floor;

    // Use this for initialization
    void Start () {
        m_Floor = GameObject.FindGameObjectWithTag("Floor");
        Robot_Forward_Pos = this.gameObject.transform.forward * 3;
        Debug.Log(Robot_Forward_Pos);

        int random = Random.Range(0, 3);
      //  type = RobotTypeManager.getRobotType();
       // Debug.Log(type);
        //RobotTypeManager.ChangeRobotType(RobotTypeManager.RobotType.StorageBattery);
      
        type = RobotTypeManager.getRobotType();
        Debug.Log(type);
        switch(type)
        {
            
            case RobotTypeManager.RobotType.StorageBattery:
                
                GameObject StarageBattery = Instantiate(m_Storage_Battery_prefab[random], this.gameObject.transform.position - Robot_Forward_Pos, Quaternion.identity) as GameObject;
                StarageBattery.name = m_Storage_Battery_prefab[random].gameObject.name;
                break;
            case RobotTypeManager.RobotType.DryBattery:
                
                GameObject DryBattery = Instantiate(m_DryBattery_prefab[random], this.gameObject.transform.position - Robot_Forward_Pos, Quaternion.identity) as GameObject;
                DryBattery.name = m_DryBattery_prefab[random].gameObject.name;
                break;
        }

        
}
	
	// Update is called once per frame
	void Update () {

        if (m_Floor.transform.position.y > this.gameObject.transform.position.y + 30)
        {
            Destroy(this.gameObject);
        }

    }
}
