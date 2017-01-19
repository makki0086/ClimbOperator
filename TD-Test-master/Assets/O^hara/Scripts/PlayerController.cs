using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// プレイヤーコントローラー
/// </summary>
public class PlayerController : MonoBehaviour
{
    //! プレイヤーポジションカウンター
    private PlayerPositionCounter counter;
    //   public Text debagtext;
    [SerializeField]
    //! プレイヤー
    private Transform m_Player;
    //! 移動開始座標
    private Vector3 startPos;
    //! 移動終了座標
    private Vector3 endPos;
    //! 角度変更開始向き
    private Quaternion startDir;
    //! 角度変更終了向き
    private Quaternion endDir;
    //! ポジションカウント
    private int count;

   
    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {

        //! デバッグ
        //Debug.Log("PlyerController__Awakeを開始しました。");

        //! プレイヤーポジションカウンターの取得
        counter = GetComponent<PlayerPositionCounter>();

        //! デバッグ
        //Debug.Log("PlyerController__Awakeを終了しました。");

    }
    /// <summary>
    /// 
    /// </summary>
    // Use this for initialization
    void Start ()
    {
        
        //! デバッグ
        //Debug.Log("PlyerController__Startを開始しました。");

        //! デバッグ
        //Debug.Log("PlyerController__Startを終了しました。");

    }

    /// <summary>
    /// 
    /// </summary>
    // Update is called once per frame
    void Update ()
    {
        
        //! デバッグ
        //Debug.Log("PlyerController__Updateを開始しました。");
        
        //! チェンジプレイヤーの呼び出し
        CHANGE_Player();

        //! デバッグ
        //Debug.Log("PlyerController__Updateを終了しました。");

    }

    /// <summary>
    /// アップポジション関数
    /// </summary>
    public void UP_Position()
    {

        //! デバッグ
        //Debug.Log("PlyerController__UP_Positionを開始しました。");

        //! 処理前のポジションカウントのデバッグ
        //Debug.Log("処理前：" + counter.PositionCount);

        //! ポジションカウントをプラスする
        counter.PositionCount = counter.PositionCount + 1;

        //! 処理後のポジションカウントのデバッグ
        //Debug.Log("処理後：" + counter.PositionCount);

        //! デバッグ
        //Debug.Log("PlyerController__UP_Positionを終了しました。");

    }

    /// <summary>
    /// ダウンポジション関数
    /// </summary>
    public void DOWN_Position()
    {

        //! デバッグ
        //Debug.Log("PlyerController__DOWN_Position開始しました。");

        //! 処理前のポジションカウントのデバッグ
        //Debug.Log("処理前："+counter.PositionCount);

        //! ポジションカウントをマイナスする
        counter.PositionCount = counter.PositionCount - 1;

        //! 処理後のポジションカウントのデバッグ
        //Debug.Log("処理後："+counter.PositionCount);

        //! デバッグ
        //Debug.Log("PlyerController__DOWN_Position終了しました。");

    }

    /// <summary>
    /// チェンジプレイヤー関数
    /// </summary>
    private void CHANGE_Player()
    {
        //! デバッグ
        //Debug.Log("PlyerController__CHANGE_Playerを開始しました。");
        
        //! カウントにプレイヤーポジションカウンターからカウントを取得する
        count = counter.PositionCount;
        
        //! カウントを調べる
        switch (count)
        {
            //! カウント1の処理
            case 1:

                //! デバッグ
                //Debug.Log("カウント１の処理を開始しました。");

                //! 角度変更開始向きに今のプレイヤーの向きを取得する
                startDir = m_Player.transform.rotation;

                //! 角度変更終了向きに終了向きを設定する
                endDir = new Quaternion(0.0f, 1.0f, 0.0f, 1.0f);

                //! プレイヤーの向きを角度変更を補完しながら向きを変更する
                m_Player.transform.rotation = Quaternion.Slerp(startDir, endDir, Time.deltaTime * 15.0f);
                
                //! 移動開始座標に今の座標を取得する
                startPos = this.gameObject.transform.position;
                
                //! 移動終了座標に終了座標を設定する
                endPos = new Vector3(-11.0f, this.gameObject.transform.position.y, 5);
                
                //! プレイヤーの座標を補完しながら座標を変更する
                this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 15);
                
                //! デバッグ
                //Debug.Log("カウント１の処理を終了しました。");
                
                //! 処理を抜ける
                break;

            //! カウント2の処理
            case 2: 

                //! デバッグ
                //Debug.Log("カウント2の処理を開始しました。");

                //! 角度変更開始向きに今のプレイヤーの向きを取得する
                startDir = m_Player.transform.rotation;

                //! 角度変更終了向きに終了向きを設定する
                endDir = new Quaternion(0, 1.0f, 0, 1);

                //! プレイヤーの向きを角度変更を補完しながら向きを変更する
                m_Player.transform.rotation = Quaternion.Slerp(startDir, endDir, Time.deltaTime * 15);

                //! 移動開始座標に今の座標を取得する
                startPos = this.gameObject.transform.position;

                //! 移動終了座標に終了座標を設定する
                endPos = new Vector3(-11, this.gameObject.transform.position.y, 1);

                //! プレイヤーの座標を補完しながら座標を変更する
                this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 15);

                //! デバッグ
                //Debug.Log("カウント2の処理を終了しました。");

                //! 処理を抜ける
                break;

            //! カウント3の処理
            case 3:

                //! デバッグ
                //Debug.Log("カウント3の処理を開始しました。");

                //! 角度変更開始向きに今のプレイヤーの向きを取得する
                startDir = m_Player.transform.rotation;

                //! 角度変更終了向きに終了向きを設定する
                endDir = new Quaternion(0, 1.0f, 0, 1);

                //! プレイヤーの向きを角度変更を補完しながら向きを変更する
                m_Player.transform.rotation = Quaternion.Slerp(startDir, endDir, Time.deltaTime * 15);

                //! 移動開始座標に今の座標を取得する
                startPos = this.gameObject.transform.position;

                //! 移動終了座標に終了座標を設定する
                endPos = new Vector3(-11, this.gameObject.transform.position.y, -3);

                //! プレイヤーの座標を補完しながら座標を変更する
                this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 15);

                //! デバッグ
                //Debug.Log("カウント3の処理を終了しました。");

                //! 処理を抜ける
                break;

            //! カウント4の処理
            case 4:

                //! デバッグ
                //Debug.Log("カウント4の処理を開始しました。");

                //! 角度変更開始向きに今のプレイヤーの向きを取得する
                startDir = m_Player.transform.rotation;

                //! 角度変更終了向きに終了向きを設定する
                endDir = new Quaternion(0, 1.0f, 0, 1);

                //! プレイヤーの向きを角度変更を補完しながら向きを変更する
                m_Player.transform.rotation = Quaternion.Slerp(startDir, endDir, Time.deltaTime * 15);

                //! 移動開始座標に今の座標を取得する
                startPos = this.gameObject.transform.position;

                //! 移動終了座標に終了座標を設定する
                endPos = new Vector3(-11, this.gameObject.transform.position.y, -7);

                //! プレイヤーの座標を補完しながら座標を変更する
                this.gameObject.transform.position = Vector3.Slerp(startPos, endPos, Time.deltaTime * 15);

                //! デバッグ
                //Debug.Log("カウント4の処理を終了しました。");

                //! 処理を抜ける
                break;

            //! カウント5の処理
            case 5:

                //! デバッグ
                //Debug.Log("カウント5の処理を開始しました。");

                //! 角度変更開始向きに今のプレイヤーの向きを取得する
                startDir = m_Player.transform.rotation;

                //! 角度変更終了向きに終了向きを設定する
                endDir = new Quaternion(0, 0.0f, 0, 1);

                //! プレイヤーの向きを角度変更を補完しながら向きを変更する
                m_Player.transform.rotation = Quaternion.Slerp(startDir, endDir, Time.deltaTime * 15);

                //! 移動開始座標に今の座標を取得する
                startPos = this.gameObject.transform.position;

                //! 移動終了座標に終了座標を設定する
                endPos = new Vector3(-7, this.gameObject.transform.position.y, -11);

                //! プレイヤーの座標を補完しながら座標を変更する
                this.gameObject.transform.position = Vector3.Slerp(startPos, endPos, Time.deltaTime * 15);

                //! デバッグ
                //Debug.Log("カウント5の処理を終了しました。");

                //! 処理を抜ける
                break;

            //! カウント6の処理
            case 6:

                //! デバッグ
                //Debug.Log("カウント6の処理を開始しました。");

                //! 角度変更開始向きに今のプレイヤーの向きを取得する
                startDir = m_Player.transform.rotation;

                //! 角度変更終了向きに終了向きを設定する
                endDir = new Quaternion(0, 0.0f, 0, 1);

                //! プレイヤーの向きを角度変更を補完しながら向きを変更する
                m_Player.transform.rotation = Quaternion.Slerp(startDir, endDir, Time.deltaTime * 15);

                //! 移動開始座標に今の座標を取得する
                startPos = this.gameObject.transform.position;

                //! 移動終了座標に終了座標を設定する
                endPos = new Vector3(-3, this.gameObject.transform.position.y, -11);

                //! プレイヤーの座標を補完しながら座標を変更する
                this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 15);

                //! デバッグ
                //Debug.Log("カウント6の処理を終了しました。");

                //! 処理を抜ける
                break;

            //! カウント7の処理
            case 7:

                //! デバッグ
                //Debug.Log("カウント7の処理を開始しました。");

                //! 角度変更開始向きに今のプレイヤーの向きを取得する
                startDir = m_Player.transform.rotation;

                //! 角度変更終了向きに終了向きを設定する
                endDir = new Quaternion(0, 0.0f, 0, 1);

                //! プレイヤーの向きを角度変更を補完しながら向きを変更する
                m_Player.transform.rotation = Quaternion.Slerp(startDir, endDir, Time.deltaTime * 15);

                //! 移動開始座標に今の座標を取得する
                startPos = this.gameObject.transform.position;

                //! 移動終了座標に終了座標を設定する
                endPos = new Vector3(1, this.gameObject.transform.position.y, -11);

                //! プレイヤーの座標を補完しながら座標を変更する
                this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 15);

                //! デバッグ
                //Debug.Log("カウント7の処理を終了しました。");

                //! 処理を抜ける
                break;

            //! カウント8の処理
            case 8:

                //! デバッグ
                //Debug.Log("カウント8の処理を開始しました。");

                //! 角度変更開始向きに今のプレイヤーの向きを取得する
                startDir = m_Player.transform.rotation;

                //! 角度変更終了向きに終了向きを設定する
                endDir = new Quaternion(0, 0.0f, 0, 1);

                //! プレイヤーの向きを角度変更を補完しながら向きを変更する
                m_Player.transform.rotation = Quaternion.Slerp(startDir, endDir, Time.deltaTime * 15);

                //! 移動開始座標に今の座標を取得する
                startPos = this.gameObject.transform.position;

                //! 移動終了座標に終了座標を設定する
                endPos = new Vector3(5, this.gameObject.transform.position.y, -11);

                //! プレイヤーの座標を補完しながら座標を変更する
                this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 15);

                //! デバッグ
                //Debug.Log("カウント8の処理を終了しました。");

                //! 処理を抜ける
                break;

        }

        //! デバッグ
        //Debug.Log("PlyerController__CHANGE_Playerを終了しました。");

    }
    
}

