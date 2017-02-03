using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{
	[SerializeField]
	private Text m_GameOver;

    [SerializeField]
    private GameObject m_Score;
    private Score score;
    [SerializeField]
    private Text m_GameOverScore;
    [SerializeField]
    private Text m_ObstacleScore;

    [SerializeField]
    private Text m_battery_LScore;

    [SerializeField]
    private Text m_battery_MScore;
    [SerializeField]
    private Text m_battery_SScore;
    [SerializeField]
    private Text m_ComprehensioScore;
    [SerializeField]
    private GameObject m_GamoverBack;

    private float timeleft;
    private int height;
    private int obstacle;
    private int battery_L;
    private int battery_M;
    private int battery_S;
    private int Comprehension;
    private bool isGameOver;
    //private bool isscorepoint;
    //private bool isobstaclecount;
    //private bool isbattery_L;
    //private bool isbattery_M;
    //private bool isbattery_S;
    

    [SerializeField]
    private GameObject m_Title;

    [SerializeField]
	private GameObject m_Restart;
    [SerializeField]
    private GameObject m_Skip;

    [SerializeField]
    private GameObject BGM;

    [SerializeField]
    private GameObject BGM2;

    /// <summary>
    /// 現在Pause中か？
    /// </summary>
    public bool pausing;

	/// <summary>
	/// 無視するGameObject
	/// </summary>
	public GameObject[] ignoreGameObjects;

	/// <summary>
	/// ポーズ状態が変更された瞬間を調べるため、前回のポーズ状況を記録しておく
	/// </summary>
	bool prevPausing;

	/// <summary>
	/// Rigidbodyのポーズ前の速度の配列
	/// </summary>
	RigidbodyVelocity[] rigidbodyVelocities;

	/// <summary>
	/// ポーズ中のRigidbodyの配列
	/// </summary>
	Rigidbody[] pausingRigidbodies;

	/// <summary>
	/// ポーズ中のMonoBehaviourの配列
	/// </summary>
	MonoBehaviour[] pausingMonoBehaviours;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Floor")
		{
			Debug.Log ("GameOver");
            m_Title.SetActive(true);
			m_Restart.SetActive(true);
            m_Skip.SetActive(true);
            BGM.SetActive(false);
            BGM2.SetActive(true);
            m_GamoverBack.SetActive(true);
            //m_Restart.localPosition = new Vector3 (0.0f, -400.0f, 0.0f);
            m_GameOver.text = "GameOver";

            isGameOver = true;
            
               
            
            m_Score.SetActive(false);
            //for(int i=0;i<score.ObstacleCount+1;i++)
            //{
                
            //}
            pausing = true;

			//Destroy(GameObject.Find("Left"));
			//Destroy(GameObject.Find("Right"));

			// Rigidbodyの停止
			// 子要素から、スリープ中でなく、IgnoreGameObjectsに含まれていないRigidbodyを抽出
			Predicate<Rigidbody> rigidbodyPredicate = 
				obj => !obj.IsSleeping() && 
				Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
			pausingRigidbodies = Array.FindAll(transform.GetComponentsInChildren<Rigidbody>(), rigidbodyPredicate);
			rigidbodyVelocities = new RigidbodyVelocity[pausingRigidbodies.Length];
			for(int i = 0; i < pausingRigidbodies.Length; i++)
			{
				// 速度、角速度も保存しておく
				rigidbodyVelocities[i] = new RigidbodyVelocity(pausingRigidbodies[i]);
				pausingRigidbodies[i].Sleep ();
			}

			// MonoBehaviourの停止
			// 子要素から、有効かつこのインスタンスでないもの、IgnoreGameObjectsに含まれていないMonoBehaviourを抽出
			Predicate<MonoBehaviour> monoBehaviourPredicate = 
				obj => obj.enabled && 
				obj != this && 
				Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
			pausingMonoBehaviours = Array.FindAll(transform.GetComponentsInChildren<MonoBehaviour>(), monoBehaviourPredicate);
			foreach(var monoBehaviour in pausingMonoBehaviours)
			{
				monoBehaviour.enabled = false;
			}
		}
	}


	// Use this for initialization
	void Start () 
	{
        isGameOver = false;
        //isscorepoint = false;
        //isobstaclecount = false;
        //isbattery_L = false;
        //isbattery_M = false;
        //isbattery_S = false;
		pausing = false;
        BGM.SetActive(true);
        BGM2.SetActive(false);
        m_Title.SetActive(false);
        m_Restart.SetActive(false);
        m_GamoverBack.SetActive(false);
        m_Skip.SetActive(false);
        score = m_Score.GetComponent<Score>();
        height = 0;
        obstacle = -1;
        battery_S = -1;
        battery_M = -1;
        battery_L = -1;
        Comprehension = 0;
    }
	
	/// <summary>
	/// 更新処理
	/// </summary>
	void Update()
	{
        if (isGameOver == true)
        {

        
            if (height == score.ScorePoint)
            {
                //isscorepoint = true;
                if (obstacle == score.ObstacleCount)
                {
                    //isobstaclecount = true;
                    if(battery_S==score.Battery_S_Count)
                    {
                        if (battery_M == score.Battery_M_Count)
                        {
                            if(battery_L==score.Battery_L_Count)
                            {
                                int value = height + (battery_S) + (battery_M*2) + (battery_L * 3) - obstacle;
                                if(Comprehension==value)
                                {
                                    
                                }
                                else
                                {
                                    Comprehension++;
                                    m_ComprehensioScore.text ="Score: "+ Comprehension;
                                    return;
                                }
                            }
                            else
                            {
                                battery_L++;
                                m_battery_LScore.text = "Battery L: + 3 x " + battery_L + " ( + " + battery_L*3+" )";
                                return;
                            }
                        }
                        else
                        {
                            battery_M++;
                            m_battery_MScore.text = "Battery M: + 2 x " + battery_M + " ( + " + battery_M*2+" )";
                            return;
                        }
                    }
                    else
                    {
                        battery_S++;
                        m_battery_SScore.text = "Battery S: + 1 x " + battery_S + " ( + " + battery_S + " )";
                        return;
                    }

                }
                else
                {
                    obstacle++;
                    m_ObstacleScore.text = "Obstacle: - 1 x" + obstacle + " ( - " + obstacle+" )";
                    return;

                }

            }
            else
            {
                height++;
                m_GameOverScore.text = "Height:" + height + " m";
                return;
            }

            //if (isscorepoint == true)
            //{
            //    if (obstacle == score.ObstacleCount)
            //    {
            //        isobstaclecount = true;
            //    }
            //    else
            //    {
            //        obstacle++;
            //        return;

            //    }
            //}


            //}
        }

    }


	/// <summary>
	/// 中断
	/// </summary>
	void Pause() {
		// Rigidbodyの停止
		// 子要素から、スリープ中でなく、IgnoreGameObjectsに含まれていないRigidbodyを抽出
		Predicate<Rigidbody> rigidbodyPredicate = 
			obj => !obj.IsSleeping() && 
			Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
		pausingRigidbodies = Array.FindAll(transform.GetComponentsInChildren<Rigidbody>(), rigidbodyPredicate);
		rigidbodyVelocities = new RigidbodyVelocity[pausingRigidbodies.Length];
		for(int i = 0; i < pausingRigidbodies.Length; i++)
		{
			// 速度、角速度も保存しておく
			rigidbodyVelocities[i] = new RigidbodyVelocity(pausingRigidbodies[i]);
			pausingRigidbodies[i].Sleep ();
		}

		// MonoBehaviourの停止
		// 子要素から、有効かつこのインスタンスでないもの、IgnoreGameObjectsに含まれていないMonoBehaviourを抽出
		Predicate<MonoBehaviour> monoBehaviourPredicate = 
			obj => obj.enabled && 
			obj != this && 
			Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
		pausingMonoBehaviours = Array.FindAll(transform.GetComponentsInChildren<MonoBehaviour>(), monoBehaviourPredicate);
		foreach(var monoBehaviour in pausingMonoBehaviours)
		{
			monoBehaviour.enabled = false;
		}

	}

	/// <summary>
	/// 再開
	/// </summary>
	void Resume() {
		// Rigidbodyの再開
		for(int i = 0; i < pausingRigidbodies.Length; i++)
		{
			pausingRigidbodies[i].WakeUp();
			pausingRigidbodies[i].velocity = rigidbodyVelocities[i].velocity;
			pausingRigidbodies[i].angularVelocity = rigidbodyVelocities[i].angularVeloccity;
		}

		// MonoBehaviourの再開
		foreach(var monoBehaviour in pausingMonoBehaviours)
		{
			monoBehaviour.enabled = true;
		}
	}
    public void Skip()
    {
        height = score.ScorePoint;
        obstacle = score.ObstacleCount;
        battery_S = score.Battery_M_Count;
        battery_M = score.Battery_M_Count;
        battery_L= score.Battery_L_Count;
        Comprehension= height + (battery_S) + (battery_M * 2) + (battery_L * 3) - obstacle;
    }


}
