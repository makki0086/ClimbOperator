using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UISelector : MonoBehaviour {

    //! ロボットのタイプ
    private RobotTypeManager.RobotType type;

    [SerializeField]
    //! バッテリーUIオブジェクト
    private GameObject[] BatteryUI;

    private Slider BatterySlider;

    //! 管理用の値
    private float value;

    //! 最大値の管理用
    private float maxValue;

    //! ステップ
    private float step;
    //! ステップカウンター
    private int stepCounter;


    //! ふりはば
    private float range;

    //! 実際の値
    private float actualValue;

    private RectTransform rt;


    void Awake()
    {
        switch (type = RobotTypeManager.getRobotType())
        {
            case RobotTypeManager.RobotType.StorageBattery:
                BatteryUI[0].SetActive(true);
                BatteryUI[1].SetActive(false);
                BatterySlider = BatteryUI[0].GetComponent<Slider>();
                break;

            case RobotTypeManager.RobotType.DryBattery:
                BatteryUI[0].SetActive(false);
                BatteryUI[1].SetActive(true);
                rt = BatteryUI[1].GetComponent<RectTransform>();
                BatterySlider = BatteryUI[1].GetComponent<Slider>();
                break;
        }
        // 初期値セット
        this.MaxValue = 3f;
        this.Value = this.MaxValue;
        SetActualValue(this.MaxValue);
        // 固定値しちゃうと最大値増えても増減させるのに同じ時間かかっちゃうので、最大値から設定する
        this.step = this.MaxValue / 200;

        this.range = 0f;
        this.stepCounter = 0;

    }
    // Use this for initialization
    void Start () {
        //  RobotTypeManager.ChangeRobotType(RobotTypeManager.RobotType.StorageBattery);

       

       

    }
	
	// Update is called once per frame
	void Update () {
        if (this.stepCounter == 0)
        {
            return;
        }
        else
        {
            if (this.range > 0)
            {
                // ダメージ
                this.Value -= this.step;
                this.range -= this.step;
            }
            else if (this.range < 0)
            {
                // 回復
                this.Value += this.step;
                this.range += this.step;
            }

        }

    }
    /// <summary>
    /// エネルギー増加
    /// </summary>
    /// <param name="val"></param>
    public void EnergyIncrease(float val)
    {
        this.range -= val;
        this.stepCounter = (int)Math.Abs(Math.Floor(this.range / this.step));
        SetActualValue(this.actualValue + val);
    }
    /// <summary>
    /// エネルギー減少
    /// </summary>
    /// <param name="val"></param>
    public void EnergyReduction(float val)
    {
        this.range += val;
        this.stepCounter = (int)Math.Abs(Math.Floor(this.range / this.step));
        SetActualValue(this.actualValue - val);
    }
    /// <summary>
    /// エネルギー交換
    /// </summary>
    /// <param name="val"></param>
    public void EnergyExchange(float val, Vector2 vec)
    {
        rt.sizeDelta = vec;
        this.MaxValue = val;
        this.Value = this.MaxValue;
        SetActualValue(this.MaxValue);
    }

    private void SetActualValue(float val)
    {
        if (val > this.MaxValue)
        {
            val = this.MaxValue;
        }
        else if (0 > val)
        {
            val = 0;
        }
        this.actualValue = val;
    }


    public float Value
    {
        get
        {
            return this.value;
        }
        set
        {
            // 最大値と0を考慮
            if (value > this.maxValue)
            {
                value = this.maxValue;
                this.range = 0f;        // コレ以降は意味ないので止める
            }
            else if (0 > value)
            {
                value = 0f;
                this.range = 0f;        // コレ以降は意味ないので止める
            }
            this.value = value;
            
            this.BatterySlider.value = this.value;
        }
    }

    private float MaxValue
    {
        get
        {
            return this.maxValue;
        }
        set
        {
            this.maxValue = value;
            this.BatterySlider.maxValue = value;    // スライダーの最大値もセット
        }
    }


    public float ActualValue
    {
        get { return this.actualValue; }
    }

    public Slider Battery_Slider
    {
        get
        {
            return BatterySlider;
        }
    }
    
}
