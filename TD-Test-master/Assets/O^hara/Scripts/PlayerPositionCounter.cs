#region Using

/**************************************************/
/**///! NameSpace                            !///**/
/**///! 簡略化するためにネームスペースを設定 !///**/
/**///! UnityEngine系のネームスペース        !///**/
/**/    using UnityEngine;                      /**/
/**///! システム系のネームスペース           !///**/
/**/    using System.Collections;               /**/
/**************************************************/

#endregion

#region PlayerPositionCounter

/// <summary>
/// プレイヤーポジションカウンタークラス
/// </summary>
public class PlayerPositionCounter : MonoBehaviour
{
    #region Valiable

    #region Public

    #endregion

    #region Private

    [SerializeField]

    private int MinCount = 0;

    [SerializeField]
    private int MaxCount = 9;

    [SerializeField]

    //! プレイヤーポジションカウント
    private int PlayerPositionCount = 4;

    #endregion

    #endregion

    /// <summary>
    /// 初期化(最初のフレームのアップデートの前に呼ばれる)
    /// </summary>
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    

    public int PositionCount
    {
        get
        {
            return PlayerPositionCount;
        }
        set
        {
            if ((value > MinCount) && (value < MaxCount))
            {
                PlayerPositionCount = value;
            }
        }
    }

}

#endregion