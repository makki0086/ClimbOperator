using UnityEngine;
using UnityEngine.UI;
using System;

using BarCallback = System.Action<Bar>;

public class Bar : MonoBehaviour
{

    /// <summary>
    /// 値を表現するスライダー
    /// </summary>
    public Slider ValueSlider;

    /// <summary>
    /// 値
    /// </summary>
    /// <value>The value.</value>
    private float Value
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
            this.ValueSlider.value = this.value;
        }
    }
    /// <summary>
    /// 管理用
    /// </summary>
    private float value;

    /// <summary>
    /// 最大値
    /// </summary>
    /// <value>The max value.</value>
    private float MaxValue
    {
        get
        {
            return this.maxValue;
        }
        set
        {
            this.maxValue = value;
            this.ValueSlider.maxValue = value;    // スライダーの最大値もセット
        }
    }
    /// <summary>
    /// 最大値の管理用
    /// </summary>
    private float maxValue;

    /// <summary>
    /// 値のステップ
    /// </summary>
    private float step;
    private int stepCounter;

    /// <summary>
    /// ふりはば
    /// </summary>
    private float range;

    /// <summary>
    /// 実際の値
    /// スライダーをアニメーションさせる関係で
    /// 含みを持たせてとめてるので、
    /// ちゃんとした値が欲しいならここを呼び出す
    /// </summary>
    /// <value>The actual value.</value>
    public float ActualValue
    {
        get { return this.actualValue; }
    }
    private float actualValue;


    private BarCallback callbackStopBar;

    // Use this for initialization
    void Awake()
    {
        // 初期値セット
        this.MaxValue = 3f;
        this.Value = this.MaxValue;
        SetActualValue(this.MaxValue);
        // 固定値しちゃうと最大値増えても増減させるのに同じ時間かかっちゃうので、最大値から設定する
        this.step = this.MaxValue / 200;

        this.range = 0f;
        this.stepCounter = 0;
        this.callbackStopBar = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.stepCounter == 0)
        {
            if (this.callbackStopBar != null)
            {
                this.callbackStopBar(this);
                this.callbackStopBar = null;
            }
            return;
        }
        else if (this.range > 0)
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
        this.stepCounter--;
    }

    /// <summary>
    /// 減少
    /// </summary>
    /// <param name="val">減少させる値</param>
    public void ReduceFrom(float val)
    {
        ReduceFrom(val, null);
    }
    /// <summary>
    /// 減少
    /// </summary>
    /// <param name="val">減少させる値</param>
    /// <param name="callback">減少アニメーションが止まった際のコールバック</param>
    public void ReduceFrom(float val, BarCallback callback)
    {
        this.range += val;
        this.stepCounter = (int)Math.Abs(Math.Floor(this.range / this.step));
        SetActualValue(this.actualValue - val);
        this.callbackStopBar = callback;
    }

    /// <summary>
    /// 増加
    /// </summary>
    /// <param name="val">増加させる値</param>
    public void GainFrom(float val)
    {
        GainFrom(val, null);
    }
    /// <summary>
    /// 増加
    /// </summary>
    /// <param name="val">増加させる値</param>
    /// <param name="callback">増加アニメーションが止まった際のコールバック</param>
    public void GainFrom(float val, BarCallback callback)
    {
        this.range -= val;
        this.stepCounter = (int)Math.Abs(Math.Floor(this.range / this.step));
        SetActualValue(this.actualValue + val);
        this.callbackStopBar = callback;
    }

    /// <summary>
    /// アニメーションなしで設定(外からリセットとかするとき
    /// </summary>
    public void SetValue(float val)
    {
        this.range = 0;
        this.Value = val;
        SetActualValue(val);
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

}