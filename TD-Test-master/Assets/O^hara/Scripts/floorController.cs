using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class floorController : MonoBehaviour {


    private RobotTypeManager.RobotType type;
    [SerializeField]
    //! バッテリーUIオブジェクト
    //private GameObject[] BatteryUI;
    private float Difference;
    [SerializeField]
    private GameObject m_plyer;
    //public float ScrollSpeed = 0.2f;
    //private MeshRenderer mr;
    //float d;
    //float offset = 0f;
     [SerializeField]
    private GameObject BatteryUI;
    Vector3 startPos;
    Vector3 endPos;
    
   // private Slider m_Slider;
    private UISelector selector;
    // Use this for initialization
    void Start()
    {
        type = RobotTypeManager.getRobotType();
        selector = BatteryUI.GetComponent<UISelector>();
        switch (type)
        {
            case RobotTypeManager.RobotType.DryBattery:
                Difference = 12;
               // m_Slider = BatteryUI[1].GetComponent<Slider>();
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, m_plyer.transform.position.y - Difference, this.gameObject.transform.position.z);


                break;
            case RobotTypeManager.RobotType.StorageBattery:
                Difference = 9;
                //m_Slider = BatteryUI[0].GetComponent<Slider>();
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, m_plyer.transform.position.y - Difference - selector.Battery_Slider.value, this.gameObject.transform.position.z);
                break;
        }
        //mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selector.Battery_Slider.value == 0)
        {

            //startPos = this.gameObject.transform.position;

            //! 移動終了座標に終了座標を設定する
            // endPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5.0f, this.gameObject.transform.position.z);


            //     this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.2f, this.gameObject.transform.position.z);

            //! 床の座標を補完しながら座標を変更する
            //     this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime);

            if (Difference >= -2)
            {

                Difference -= 0.084f;
            }


        }// else
      //  {
            switch (type)
            {
                case RobotTypeManager.RobotType.DryBattery:
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, m_plyer.transform.position.y - Difference, this.gameObject.transform.position.z);
                    //startPos = this.gameObject.transform.position;

                    //! 移動終了座標に終了座標を設定する
                    //endPos = new Vector3(this.gameObject.transform.position.x, m_plyer.transform.position.y - Difference, this.gameObject.transform.position.z);

                    //! 床の座標を補完しながら座標を変更する
                    // this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime);


                    break;
                case RobotTypeManager.RobotType.StorageBattery:
                    //startPos = this.gameObject.transform.position;

                    //! 移動終了座標に終了座標を設定する
                    //endPos = new Vector3(this.gameObject.transform.position.x, m_plyer.transform.position.y - Difference - selector.Battery_Slider.value, this.gameObject.transform.position.z);

                    //! 床の座標を補完しながら座標を変更する
                    // this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime);

                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, m_plyer.transform.position.y - Difference - selector.Battery_Slider.value, this.gameObject.transform.position.z);
                    break;
            }

        //}



        //! 移動開始座標に今の座標を取得する


        //d +=Time.deltaTime;
        //if (1 < d)
        //{
        //    d = 0;
        //    int r = Random.Range(0, 3 + 1);
        //    if (r == 0)
        //    {
        //        offset = Mathf.Repeat(Time.time * ScrollSpeed, 1f);
        //        offset = 1f - offset; //逆向きに動かしたい場合
        //        mr.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
        //    }
        //    if (r == 1)
        //    {
        //        offset = Mathf.Repeat(Time.time * ScrollSpeed, 1f);
        //        // offset = 1f - offset; //逆向きに動かしたい場合
        //        mr.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
        //    }

        //    if (r == 2)
        //    {
        //        offset = Mathf.Repeat(Time.time * ScrollSpeed, 1f);
        //        offset = 1f - offset; //逆向きに動かしたい場合
        //        mr.material.SetTextureOffset("_MainTex", new Vector2(offset,0f));
        //    }
        //    if (r == 3)
        //    {
        //        offset = Mathf.Repeat(Time.time * ScrollSpeed, 1f);
        //        // offset = 1f - offset; //逆向きに動かしたい場合
        //        mr.material.SetTextureOffset("_MainTex", new Vector2(offset,0f));
        //    }
        //}
    }
    
}
