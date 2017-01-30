using UnityEngine;
using System.Collections;

public class ObstacleFactory : MonoBehaviour {
    
    //! 最大障害物数
    private int MaxObstacle;

    [SerializeField]
    //! 障害物のプレハブ
    private GameObject [] m_obstacle_prefab;

    //! 障害物の座標
    private Vector3 m_obstacle_pos;

    private Quaternion m_obstacle_dir;

    //! 障害物が作れるか
    private bool [] ismakeobstacle;

    //! 障害物を作る数
    private int MakeObstacleValue;

    //! 障害物の最小数
    private int MakeObstacleValue_Min;

    //! 障害物の最大数
    private int MakeObstacleValue_Max;

    private int MakeValue;

    private int ObstacleNo;

    

    // Use this for initialization
    void Start () {
        init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void init()
    {
        MaxObstacle = 8;

        ismakeobstacle = new bool[MaxObstacle];
        for (int i = 0; i < MaxObstacle; i++)
        {
            ismakeobstacle[i] = false;
            Debug.Log(ismakeobstacle[i]);
        }

        MakeObstacleValue_Min = 1;
        MakeObstacleValue_Max = 6;

        MakeObstacleValue = Random.Range(MakeObstacleValue_Min, MakeObstacleValue_Max + 1);

        for (int i = 0; i < MakeObstacleValue; i++)
        {
            MakeValue = Random.Range(0, MaxObstacle);
            if (ismakeobstacle[MakeValue] == false)
            {

                ismakeobstacle[MakeValue] = true;
                ObstacleNo = 0;
                switch (MakeValue)
                {
                    case 0:
                        m_obstacle_pos = new Vector3(-11.0f, this.gameObject.transform.position.y, 5.0f);
                        m_obstacle_dir = new Quaternion(0.0f, 1.0f, 0.0f, 1);
                        // Debug.Log("0");
                        break;
                    case 1:
                        m_obstacle_pos = new Vector3(-11.0f, this.gameObject.transform.position.y, 1.0f);
                        m_obstacle_dir = new Quaternion(0.0f, 1.0f, 0.0f, 1);
                        // Debug.Log("1");
                        break;
                    case 2:
                        m_obstacle_pos = new Vector3(-11.0f, this.gameObject.transform.position.y, -3.0f);
                        m_obstacle_dir = new Quaternion(0.0f, 1.0f, 0.0f, 1);
                        // Debug.Log("2");
                        break;
                    case 3:
                        m_obstacle_pos = new Vector3(-11.0f, this.gameObject.transform.position.y, -7.0f);
                        m_obstacle_dir = new Quaternion(0.0f, 1.0f, 0.0f, 1);
                        Debug.Log("3");
                        break;
                    case 4:
                        m_obstacle_pos = new Vector3(-7.0f, this.gameObject.transform.position.y, -11.0f);
                        m_obstacle_dir = new Quaternion(0.0f, 0.0f, 0.0f, 1);
                        // Debug.Log("4");
                        break;
                    case 5:
                        m_obstacle_pos = new Vector3(-3.0f, this.gameObject.transform.position.y, -11.0f);
                        m_obstacle_dir = new Quaternion(0.0f, 0.0f, 0.0f, 1);
                        //Debug.Log("5");
                        break;
                    case 6:
                        m_obstacle_pos = new Vector3(1.0f, this.gameObject.transform.position.y, -11.0f);
                        m_obstacle_dir = new Quaternion(0.0f, 0f, 0.0f, 1);
                        //Debug.Log("6");
                        break;
                    case 7:
                        m_obstacle_pos = new Vector3(5.0f, this.gameObject.transform.position.y, -11.0f);
                        m_obstacle_dir = new Quaternion(0.0f, 0.0f, 0.0f, 1);
                        //Debug.Log("7");
                        break;
                }

                GameObject Obstacle = Instantiate(m_obstacle_prefab[ObstacleNo], m_obstacle_pos, m_obstacle_dir) as GameObject;
                Obstacle.name = m_obstacle_prefab[ObstacleNo].name;
            }
            else
            {
                continue;
            }



        }
    }
   
}
