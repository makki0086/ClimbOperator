using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StorageBattery : MonoBehaviour {

    [SerializeField]
    private Slider m_slider;

    //! 電池があるか
    private bool isBattery;

    private float defolt;    


	// Use this for initialization
	void Start () {

        m_slider = this.gameObject.GetComponent<Slider>();
        m_slider.maxValue = 3.0f;
        m_slider.value = 3.0f;

	}
	
	// Update is called once per frame
	void Update () {

       // DownBattery(0.00084f);
	
	}
    public  void UpBattery(float val )
    {
        float value = m_slider.value;
        if(m_slider.maxValue<value+val)
        {
            m_slider.value = m_slider.maxValue;
        }
        else
        {
            m_slider.value += val;
        }

        
    }

    public void DownBattery(float val)
    {
        float value = m_slider.value;
        if(m_slider.minValue>value-val)
        {
            m_slider.value = m_slider.minValue;
        }
        else
        {
            //for(float i=0.0f;m_slider.value==value-val;0.01f--)
            //{

            //}
           // m_slider.value=Mathf.Lerp(value, value - val, 5);
            //m_slider.value -= val;
        }
    }
}
