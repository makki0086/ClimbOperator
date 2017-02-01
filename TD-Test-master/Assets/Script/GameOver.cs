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
    [SerializeField]
    private Text m_GameOverScore;

   

    [SerializeField]
    private GameObject m_Title;

    [SerializeField]
	private GameObject m_Restart;

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
            BGM.SetActive(false);
            BGM2.SetActive(true);
            //m_Restart.localPosition = new Vector3 (0.0f, -400.0f, 0.0f);
            m_GameOver.text = "GameOver";
            m_GameOverScore.text =  m_Score.GetComponent<Text>().text;
            m_Score.SetActive(false);
            pausing = true;

			Destroy(GameObject.Find("Left"));
			Destroy(GameObject.Find("Right"));

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
		pausing = false;
        BGM.SetActive(true);
        BGM2.SetActive(false);
    }
	
	/// <summary>
	/// 更新処理
	/// </summary>
	void Update()
	{

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


}
