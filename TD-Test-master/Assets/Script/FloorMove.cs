using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloorMove : MonoBehaviour 
{
	[SerializeField]
	private Transform m_Floor;

	[SerializeField]
	private Transform m_Player;

	private bool m_Pausing;

    [SerializeField]
    private GameObject BatteryUI;
    //private Slider m_Slider;
    private UISelector selector;

    // Use this for initialization
    void Start () 
	{
        selector = BatteryUI.GetComponent<UISelector>();
    }
	
	// Update is called once per frame
	void Update () 
	{
		m_Pausing = GameObject.Find("Player").GetComponent<GameOver>().pausing;

		if (m_Pausing == false)
		{
			
		//	m_Floor.position = new Vector3 (m_Floor.position.x, m_Player.position.y - 13.0f * m_Slider.value, m_Floor.position.z);
            m_Floor.position = new Vector3(m_Floor.position.x, m_Player.position.y - selector.ActualValue, m_Floor.position.z);
        }

	}
}
