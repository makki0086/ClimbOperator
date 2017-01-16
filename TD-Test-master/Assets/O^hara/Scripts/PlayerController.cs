using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// プレイヤーコントローラー
/// </summary>
public class PlayerController : MonoBehaviour {
    PlayerPositionCounter counter;
    //   public Text debagtext;
    [SerializeField]
    private Transform m_Player;
    private Vector3 startPos;
    private Vector3 endPos;
    private Quaternion startRot;
    private Quaternion endRot;
    private bool end;
    
    
    void Awake()
    {
        Debug.Log("Awake");
        counter = GetComponent<PlayerPositionCounter>();
    }
    // Use this for initialization
    void Start () {

        
        end = true;

    }
	
	// Update is called once per frame
	void Update () {
       
        if(end==true)
        {
            int co = counter.PositionCount;
            //   debagtext.text = counter.PositionCount.ToString();
            switch (co)
            {
                case 1:
                    //this.gameObject.transform.position = new Vector3(-11, this.gameObject.transform.position.y, 5);
                    startRot = m_Player.transform.rotation;
                    endRot = new Quaternion(0, 1.0f, 0, 1);
                    m_Player.transform.rotation = Quaternion.Slerp(startRot, endRot, Time.deltaTime*15);
                    startPos = this.gameObject.transform.position;
                    endPos = new Vector3(-11, this.gameObject.transform.position.y, 5);
                    this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime*15);
                    break;
                case 2:
                    // this.gameObject.transform.position = new Vector3(-11, this.gameObject.transform.position.y, 1);
                    startRot = m_Player.transform.rotation;
                    endRot = new Quaternion(0, 1.0f, 0, 1);
                    m_Player.transform.rotation = Quaternion.Slerp(startRot, endRot, Time.deltaTime*15);
                    //this.gameObject.transform.TransformDirection(-11, this.gameObject.transform.position.y, 1);
                    startPos = this.gameObject.transform.position;
                    endPos = new Vector3(-11, this.gameObject.transform.position.y, 1);
                    this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime*15);
                    break;
                case 3:
                    startRot = m_Player.transform.rotation;
                    endRot = new Quaternion(0, 1.0f, 0, 1);
                    m_Player.transform.rotation = Quaternion.Slerp(startRot, endRot, Time.deltaTime*15);
                    startPos = this.gameObject.transform.position;
                    endPos = new Vector3(-11, this.gameObject.transform.position.y, -3);
                    this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime*15);
                    //this.gameObject.transform.position = new Vector3(-11, this.gameObject.transform.position.y, -3);

                    break;
                case 4:
                    //m_Player.transform.rotation = new Quaternion(0, 1.0f, 0, 1);
                    startRot = m_Player.transform.rotation;
                    endRot = new Quaternion(0, 1.0f, 0, 1);
                    m_Player.transform.rotation = Quaternion.Slerp(startRot, endRot, Time.deltaTime*15);
                    startPos = this.gameObject.transform.position;
                    endPos = new Vector3(-11, this.gameObject.transform.position.y, -7);
                    this.gameObject.transform.position = Vector3.Slerp(startPos, endPos, Time.deltaTime*15);
                    //this.gameObject.transform.position = new Vector3(-11, this.gameObject.transform.position.y, -7);


                    break;
                case 5:
                    startRot = m_Player.transform.rotation;
                    endRot = new Quaternion(0, 0.0f, 0, 1);
                    m_Player.transform.rotation = Quaternion.Slerp(startRot, endRot, Time.deltaTime*15);
                    startPos = this.gameObject.transform.position;
                    endPos = new Vector3(-7, this.gameObject.transform.position.y, -11);

                    this.gameObject.transform.position = Vector3.Slerp(startPos, endPos, Time.deltaTime*15);
                    //m_Player.transform.rotation = new Quaternion(0, 0.0f, 0, 1);
                    //this.gameObject.transform.position = new Vector3(-7, this.gameObject.transform.position.y, -11);
                    break;
                case 6:
                    startRot = m_Player.transform.rotation;
                    endRot = new Quaternion(0, 0.0f, 0, 1);
                    m_Player.transform.rotation = Quaternion.Slerp(startRot, endRot, Time.deltaTime*15);
                    //this.gameObject.transform.position = new Vector3(-3, this.gameObject.transform.position.y, -11);
                    startPos = this.gameObject.transform.position;
                    endPos = new Vector3(-3, this.gameObject.transform.position.y, -11);
                    this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime*15);
                    break;
                case 7:
                    startRot = m_Player.transform.rotation;
                    endRot = new Quaternion(0, 0.0f, 0, 1);
                    m_Player.transform.rotation = Quaternion.Slerp(startRot, endRot, Time.deltaTime*15);
                    //this.gameObject.transform.position = new Vector3(1, this.gameObject.transform.position.y, -11);
                    startPos = this.gameObject.transform.position;
                    endPos = new Vector3(1, this.gameObject.transform.position.y, -11);
                    this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime*15);
                    break;
                case 8:
                    startRot = m_Player.transform.rotation;
                    endRot = new Quaternion(0, 0.0f, 0, 1);
                    m_Player.transform.rotation = Quaternion.Slerp(startRot, endRot, Time.deltaTime*15);
                    startPos = this.gameObject.transform.position;
                    endPos = new Vector3(5, this.gameObject.transform.position.y, -11);
                    this.gameObject.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime*15);
                    //this.gameObject.transform.position = new Vector3(5, this.gameObject.transform.position.y, -11);
                    break;
            }
        }
       

    }
    public void UP_Position()
    {
        Debug.Log(counter.PositionCount);
        counter.PositionCount = counter.PositionCount + 1;
        Debug.Log(counter.PositionCount);
    } 
    public void DOWN_Position()
    {
        Debug.Log(counter.PositionCount);
        counter.PositionCount = counter.PositionCount - 1;
        Debug.Log(counter.PositionCount);
    }

    //public void s(AngleManager angle)
    //{
    //    switch (angle.Angle)
    //    {
    //        case AngleManager.Angle_Value.UP:
    //            {
    //                Debug.Log("UP");
    //                break;
    //            }

    //        case AngleManager.Angle_Value.RIGHT:
    //            {
    //                Debug.Log(counter.PositionCount);
    //              //  counter.PositionCount = counter.PositionCount + 1;
    //                break;
    //            }
    //    }

    //    angle.AzimuthUpdate();
    //}

}

