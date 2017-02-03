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
    //! プレイヤーの座標
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

    // [SerializeField]
    //! フロアの座標
    // private Transform m_Floor;
    //! プレイヤーが登る速さ
    private float moveSpeed_Y;

    //private StorageBattery storageBattery;
    //[SerializeField]
    //private GameObject StorageBatteryUI;

    //  private GameObject m_Battery;
    //private GameObject m_Battery_Back;
    //  private Slider m_Slider;

    private bool isBattery;

    private RobotTypeManager.RobotType type;
    [SerializeField]
    private GameObject BatteryUI;
    private UISelector selector;

    private bool isSkill;
    [SerializeField]
   // private GameObject m_Score;
    private Score score;



    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {

        //! デバッグ
        //Debug.Log("PlyerController__Awakeを開始しました。");

        //! プレイヤーポジションカウンターの取得
        counter = GetComponent<PlayerPositionCounter>();
        selector = BatteryUI.GetComponent<UISelector>();
        //score = m_Score.GetComponent<Score>();
        
        // storageBattery = StorageBatteryUI.GetComponent<StorageBattery>();
        //! デバッグ
        //Debug.Log("PlyerController__Awakeを終了しました。");

    }
    /// <summary>
    /// 
    /// </summary>
    // Use this for initialization
    void Start()
    {

        //! デバッグ
        //Debug.Log("PlyerController__Startを開始しました。");
        //localGravity = new Vector3(0, 0.5f, 0);
        //m_Battery = GameObject.Find("DryBattery");

        // m_Slider = m_Battery.GetComponent<Slider>();

        // m_Slider.value = 3.0f;
        // moveSpeed_Y = m_Slider.value/30;
        //isBattery = true;
        type = RobotTypeManager.getRobotType();
        isSkill = false;
        //! デバッグ
        //Debug.Log("PlyerController__Startを終了しました。");

    }

    /// <summary>
    /// 
    /// </summary>
    // Update is called once per frame
    void Update()
    {

        if (selector.Battery_Slider.value <= 0)
        {

            moveSpeed_Y = 0.1f;
        }
        else
        {


            switch (type)
            {
                case RobotTypeManager.RobotType.DryBattery:
                    moveSpeed_Y = 0.3f;
                    break;
                case RobotTypeManager.RobotType.StorageBattery:
                    moveSpeed_Y = selector.ActualValue / 10f + 0.05f;
                    break;
            }

        }
        selector.EnergyReduction(0.00084f);
        //m_Slider.value -= 0.00084f;
        // moveSpeed_Y = m_Slider.value / 10 + 0.2f;
        // if(m_Slider.value<=0)
        //  {
        //      isBattery = false;
        //    m_Slider.value = 0;
        //  }
        //moveSpeed_Y -= 0.0008f;
        //moveSpeed_Y = 0.3f;
        // float a = this.gameObject.transform.position.y;
        // float b = a += moveSpeed_Y;
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + moveSpeed_Y, this.gameObject.transform.position.z);


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
    public void Skill()
    {
        if (selector.Battery_Slider.value <= 0)
        {
            return;
        }
        else
        { 
            foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
            {
                // シーン上に存在するオブジェクトならば処理.
                if (obj.activeInHierarchy)
                {
                    // GameObjectの名前を表示.
                    // Debug.Log(obj.name);
                    if (obj.tag == "Obstacle")
                    {
                        if (m_Player.transform.position.x == obj.transform.position.x && m_Player.transform.position.z == obj.transform.position.z)
                        {
                            // Debug.Log(obj.name);
                            Obstacle a = obj.GetComponent<Obstacle>();
                            a.Speed = 0;
                            isSkill = true;
                            //  StartCoroutine("aa",obj);
                            // Debug.Log("aa");

                        }
                    }
                }

            }
            if (isSkill)
            {
                selector.EnergyReduction(0.25f);
                isSkill = false;
            }
        }
    
    }
    public void Skill2()
    {
        if (selector.Battery_Slider.value <= 0)
        {
            return;
        }
        else
        { 
            foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
            {
                // シーン上に存在するオブジェクトならば処理.
                if (obj.activeInHierarchy)
                {
                    // GameObjectの名前を表示.
                    // Debug.Log(obj.name);
                    if (obj.tag == "Obstacle")
                    {
                        if (m_Player.transform.position.x == obj.transform.position.x && m_Player.transform.position.z == obj.transform.position.z)
                        {
                            count = counter.PositionCount;

                            //! カウントを調べる
                            switch (count)
                            {
                                //! カウント1の処理
                                case 1:

                                    //! デバッグ
                                    //Debug.Log("カウント１の処理を開始しました。");

                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-11.0f, obj.transform.position.y + 10, 1);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント１の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント2の処理
                                case 2:

                                    //! デバッグ
                                    //Debug.Log("カウント2の処理を開始しました。");

                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-11, obj.transform.position.y + 10, 5);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント2の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント3の処理
                                case 3:

                                    //! デバッグ
                                    //Debug.Log("カウント3の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-11, obj.transform.position.y + 10, -7);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント3の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント4の処理
                                case 4:

                                    //! デバッグ
                                    //Debug.Log("カウント4の処理を開始しました。");

                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-11, obj.transform.position.y + 10, -7);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント4の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント5の処理
                                case 5:

                                    //! デバッグ
                                    //Debug.Log("カウント5の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-3, obj.transform.position.y + 10, -11);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント5の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント6の処理
                                case 6:

                                    //! デバッグ
                                    //Debug.Log("カウント6の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(1, obj.transform.position.y + 10, -11);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント6の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント7の処理
                                case 7:

                                    //! デバッグ
                                    //Debug.Log("カウント7の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(5, obj.transform.position.y + 10, -11);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント7の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント8の処理
                                case 8:

                                    //! デバッグ
                                    //Debug.Log("カウント8の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(5, obj.transform.position.y + 10, -11);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    
                                   
                                    //! デバッグ
                                    //Debug.Log("カウント8の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;


                            }
                        }
                    }
                }
            }
            if (isSkill)
            {
                selector.EnergyReduction(0.25f);
                isSkill = false;
            }
        }
    }
    public void Skill3()
    {
        if (selector.Battery_Slider.value <= 0)
        {
            return;
        }
        else
        { 
            foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
            {
                // シーン上に存在するオブジェクトならば処理.
                if (obj.activeInHierarchy)
                {
                    // GameObjectの名前を表示.
                    // Debug.Log(obj.name);
                    if (obj.tag == "Obstacle")
                    {
                        if (m_Player.transform.position.x == obj.transform.position.x && m_Player.transform.position.z == obj.transform.position.z)
                        {
                            count = counter.PositionCount;

                            //! カウントを調べる
                            switch (count)
                            {
                                //! カウント1の処理
                                case 1:

                                    //! デバッグ
                                    //Debug.Log("カウント１の処理を開始しました。");

                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-11.0f, obj.transform.position.y + 10, 5);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント１の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント2の処理
                                case 2:

                                    //! デバッグ
                                    //Debug.Log("カウント2の処理を開始しました。");

                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-11, obj.transform.position.y + 10, 5);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント2の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント3の処理
                                case 3:

                                    //! デバッグ
                                    //Debug.Log("カウント3の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-11, obj.transform.position.y + 10, -1);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント3の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント4の処理
                                case 4:

                                    //! デバッグ
                                    //Debug.Log("カウント4の処理を開始しました。");

                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-11, obj.transform.position.y + 10, -3);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント4の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント5の処理
                                case 5:

                                    //! デバッグ
                                    //Debug.Log("カウント5の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-7, obj.transform.position.y + 10, -11);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント5の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント6の処理
                                case 6:

                                    //! デバッグ
                                    //Debug.Log("カウント6の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-7, obj.transform.position.y + 10, -11);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント6の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント7の処理
                                case 7:

                                    //! デバッグ
                                    //Debug.Log("カウント7の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(-3, obj.transform.position.y + 10, -11);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント7の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;

                                //! カウント8の処理
                                case 8:

                                    //! デバッグ
                                    //Debug.Log("カウント8の処理を開始しました。");


                                    //! 移動開始座標に今の座標を取得する
                                    startPos = obj.transform.position;

                                    //! 移動終了座標に終了座標を設定する
                                    endPos = new Vector3(1, obj.transform.position.y + 10, -11);

                                    //! プレイヤーの座標を補完しながら座標を変更する
                                    obj.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * 30);
                                    isSkill = true;
                                    //! デバッグ
                                    //Debug.Log("カウント8の処理を終了しました。");

                                    //! 処理を抜ける
                                    break;


                            }
                        }
                    }
                }
            }
            if (isSkill)
            {
                selector.EnergyReduction(0.25f);
                isSkill = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.tag == "Battery_S")
        {
            switch (type)
            {
                case RobotTypeManager.RobotType.DryBattery:
                    selector.EnergyExchange(1, new Vector2(80, 100));
                    break;
                case RobotTypeManager.RobotType.StorageBattery:
                    selector.EnergyIncrease(0.5f);
                    //  storageBattery.UpBattery(0.1f);
                    Debug.Log("hit");
                    break;
            }
            //storageBattery.UpBattery(0.1f);
            score.Battery_S_Count = 1;

        }
        if (collision.transform.tag == "Battery_M")
        {
            switch (type)
            {
                case RobotTypeManager.RobotType.DryBattery:
                    selector.EnergyExchange(2, new Vector2(80, 200));
                    break;
                case RobotTypeManager.RobotType.StorageBattery:
                    selector.EnergyIncrease(1.0f);
                    //  storageBattery.UpBattery(0.1f);
                    Debug.Log("hit");
                    break;
            }
            score.Battery_M_Count = 1;
            //storageBattery.UpBattery(0.1f);
            Debug.Log("hit");
        }
        if (collision.transform.tag == "Battery_L")

        {
            switch (type)
            {
                case RobotTypeManager.RobotType.DryBattery:
                    selector.EnergyExchange(3, new Vector2(80, 300));
                    break;
                case RobotTypeManager.RobotType.StorageBattery:
                    selector.EnergyIncrease(2.0f);
                    //  storageBattery.UpBattery(0.1f);
                    Debug.Log("hit");
                    break;
            }
            //storageBattery.UpBattery(0.1f);
            score.Battery_L_Count = 1;
            Debug.Log("hit");
        }
        if (collision.transform.tag == "Obstacle")
        {
            selector.EnergyReduction(0.5f);
            score.ObstacleCount = 1;
           // Debug.Log(obstaclecount.ObstacleCount);

        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            selector.EnergyReduction(0.00016f);


        }
    }
}


