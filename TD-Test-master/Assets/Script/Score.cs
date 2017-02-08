using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	[SerializeField]
	private Transform m_Player;

	[SerializeField]
	private Text m_Text;

	private float m_Score;

	private int m_ToInt;
    private int m_obstaclecount;

    private int m_Battery_L_count;

    private int m_Battery_M_count;

    private int m_Battery_S_count;

	// Use this for initialization
	void Start () 
	{
        m_obstaclecount = 0;
		m_Score = 0;
		m_Text.text = "Height:0m";
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_Score = m_Player.position.y - 1;
        m_ToInt = (int)m_Score;
		m_Text.text = "Height:" + m_ToInt.ToString ()+"m";
	}

    public int ScorePoint
    {
        get
        {
            return m_ToInt;
        }
    }
    public int ObstacleCount
    {
        get
        {
            return m_obstaclecount;
        }
        set
        {
            m_obstaclecount += value;
        }
    }
    public  int Battery_L_Count
    {
        get
        {
            return m_Battery_L_count;
        }
        set
        {
            m_Battery_L_count += value;
        }
    }
    public int Battery_M_Count
    {
        get
        {
            return m_Battery_M_count;
        }
        set
        {
            m_Battery_M_count += value;
        }
    }
    public int Battery_S_Count
    {
        get
        {
            return m_Battery_S_count;
        }
        set
        {
            m_Battery_S_count += value;
        }
    }

}
