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

#region ScreenManeger

/// <summary>
/// スクリーンマネージャークラス
/// </summary>
public class ScreenManeger : MonoBehaviour
{
    
    #region Valiable

    //! スクリーンサイズクラス
    public ScreenSize screenSize;

    #endregion

    #region Start
    /// <summary>
    /// 初期化(アップデートが呼ばれる前に一度だけ呼ばれる)
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
        //! スクリーンサイズクラスをインスタンス化
        screenSize = new ScreenSize();
        //! スクリーンサイズクラスを初期化
        screenSize.Init();

    }
    #endregion

    #region Update
    /// <summary>
    /// アップデート(1フレーム毎に呼ばれる)
    /// Update is called once per frame
    /// </summary>
    void Update ()
    {
	
	}

    #endregion

}

#endregion

#region ScreenSize
/// <summary>
/// スクリーンサイズクラス
/// </summary>
public class ScreenSize:MonoBehaviour
{

    #region Valiable
    
    //! 画面サイズ
    private Vector2 screen_Size_XY;
    
    //! 画面サイズX
    private float screen_Size_X;
    
    //! 画面サイズY
    private float screen_Size_Y;
    
    #endregion

    #region Init
    /// <summary>
    /// 初期化
    /// </summary>
    public void Init()
    {

        //! 画面サイズXをスクリーンの横サイズから取得
        screen_Size_X = Screen.width;
        
        //! 画面サイズYをスクリーンの縦サイズから取得
        screen_Size_Y = Screen.height;
        
        //! 画面サイズXYを画面サイズX,Yで設定
        screen_Size_XY = new Vector2(screen_Size_X, screen_Size_Y);

    }

    #endregion

    #region Get,Set_ScreenSize

    #region Get,Set_ScreenSize_XY
    /// <summary>
    /// 画面サイズXYのGet,Set関数
    /// </summary>
    public Vector2 screenSize_XY
    {
        
        //! ゲット
        get
        {

            //! 画面サイズXYを返す
            return screen_Size_XY;

        }

        //! セット
        set
        {

            //! 画面サイズXYを設定
            screen_Size_XY = value;

        }

    }

    #endregion

    #region Get,Set_ScreenSize_X
    /// <summary>
    /// 画面サイズXのGet,Set関数
    /// </summary>
    public float screenSize_X
    {
        //! ゲット
        get
        {

            //! 画面サイズXを返す
            return screen_Size_X;

        }

        //! セット
        set
        {

            //! 画面サイズXを設定
            screen_Size_X = value;

        }

    }

    #endregion
    
    #region Get,Set_ScreenSize_Y
    /// <summary>
    /// 画面サイズYのGet,Set関数
    /// </summary>
    public float screenSize_Y
    {

        //! ゲット
        get
        {

            //! 画面サイズYを返す
            return screen_Size_Y;

        }

        //! セット
        set
        {

            //! 画面サイズYを設定
            screen_Size_Y = value;

        }

    }
    #endregion

    #endregion

}
#endregion

#region FileData

/********************************************************************/
/* @file   ScreenManager.cs   ・ファイル名　スクリーンマネージャー  */
/* @brief  ScreenManegement   ・内容　　　　画面管理　　　  　 　　 */
/* @author Masaki.O^hara      ・作者　　　　大原　昌樹　　　　　    */
/* @date   2016/12/09         ・日付　　　　2016/12/09      　　    */
/********************************************************************/

#endregion