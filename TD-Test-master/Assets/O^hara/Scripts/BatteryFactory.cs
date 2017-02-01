using UnityEngine;
using System.Collections;

public class BatteryFactory : MonoBehaviour {

    [SerializeField]
    //! サポートロボットのプレハブ
    private GameObject m_supportrobot_prefab;
    //! サポートロボットの座標
    private Vector3 m_supportrobot_pos;
    //! サポートロボットの向き
    private Quaternion m_supportrobot_Dir;

    
    
    //! バッテリーがつくれるか
    private bool [] ismakeRobot;
    private int MaxBattery;
	// Use this for initialization
	void Start () {
        MaxBattery = 8;
       
        ismakeRobot = new bool[MaxBattery];
        for(int i=0;i<MaxBattery;i++)
        {
            ismakeRobot[i] = false;
            Debug.Log(ismakeRobot[i]);
        }
        int MakeRobotVolue = Random.Range(1,3+1);
        Debug.Log("MakeRobotVolue" + MakeRobotVolue);
        for (int i = 0; i < MakeRobotVolue; i++)
        {
            int value = Random.Range(0, MaxBattery);
            if (ismakeRobot[value] == false)
            {
                ismakeRobot[value] = true;
                switch (value)
                {
                    case 0:
                        m_supportrobot_pos = new Vector3(-8.0f, this.gameObject.transform.position.y +1, 5.0f);
                        m_supportrobot_Dir = new Quaternion(0.0f, 1.0f, 0.0f, 1);
                       // Debug.Log("0");
                        break;
                    case 1:
                        m_supportrobot_pos = new Vector3(-8.0f, this.gameObject.transform.position.y +1, 1.0f);
                        m_supportrobot_Dir = new Quaternion(0.0f, 1.0f, 0.0f, 1);
                       // Debug.Log("1");
                        break;
                    case 2:
                        m_supportrobot_pos = new Vector3(-8.0f, this.gameObject.transform.position.y +1, -3.0f);
                        m_supportrobot_Dir = new Quaternion(0.0f, 1.0f, 0.0f, 1);
                       // Debug.Log("2");
                        break;
                    case 3:
                        m_supportrobot_pos = new Vector3(-8.0f, this.gameObject.transform.position.y + 1, -7.0f);
                        m_supportrobot_Dir = new Quaternion(0.0f, 1.0f, 0.0f, 1);
                        Debug.Log("3");
                        break;
                    case 4:
                        m_supportrobot_pos = new Vector3(-7.0f, this.gameObject.transform.position.y +1, -8.0f);
                        m_supportrobot_Dir = new Quaternion(0.0f, 0.0f, 0.0f, 1);
                       // Debug.Log("4");
                        break;
                    case 5:
                        m_supportrobot_pos = new Vector3(-3.0f, this.gameObject.transform.position.y +1, -8.0f);
                        m_supportrobot_Dir = new Quaternion(0.0f, 0.0f, 0.0f, 1);
                        //Debug.Log("5");
                        break;
                    case 6:
                        m_supportrobot_pos = new Vector3(1.0f, this.gameObject.transform.position.y+1, -8.0f);
                        m_supportrobot_Dir = new Quaternion(0.0f, 0f, 0.0f, 1);
                        //Debug.Log("6");
                        break;
                    case 7:
                        m_supportrobot_pos = new Vector3(5.0f, this.gameObject.transform.position.y+1, -8.0f);
                        m_supportrobot_Dir = new Quaternion(0.0f,0.0f, 0.0f, 1);
                        //Debug.Log("7");
                        break;
                }

                GameObject SupportRobot = Instantiate(m_supportrobot_prefab, m_supportrobot_pos, m_supportrobot_Dir) as GameObject;
               // SupportRobot.transform.parent = transform;
            }
            else
            {
                continue;
            }
        }
        //for (int i = 0; i < MaxBattery; i++)
        //{

        //    Debug.Log(ismakeBattery[i]);

        //}
        // GameObject SupportRobot = Instantiate(m_supportrobot_prefab, this.gameObject.transform.position, Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
