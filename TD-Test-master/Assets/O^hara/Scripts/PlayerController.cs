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
    void Awake()
    {
        Debug.Log("Awake");
        counter = GetComponent<PlayerPositionCounter>();
    }
    // Use this for initialization
    void Start () {

        


    }
	
	// Update is called once per frame
	void Update () {
        int co = counter.PositionCount;
     //   debagtext.text = counter.PositionCount.ToString();
        switch (co)
        {
            case 1:
                this.gameObject.transform.position = new Vector3(-11, this.gameObject.transform.position.y, 5);
                
                break;
            case 2:
                this.gameObject.transform.position = new Vector3(-11, this.gameObject.transform.position.y, 1);
                break;
            case 3:
                this.gameObject.transform.position = new Vector3(-11, this.gameObject.transform.position.y, -3);
                break;
            case 4:
                m_Player.transform.rotation = new Quaternion(0, 1f, 0, 1);
                this.gameObject.transform.position = new Vector3(-11, this.gameObject.transform.position.y, -7);
                break;
            case 5:
                m_Player.transform.rotation = new Quaternion(0, 0f, 0, 1);
                this.gameObject.transform.position = new Vector3(-7, this.gameObject.transform.position.y, -11);
                break;
            case 6:
                this.gameObject.transform.position = new Vector3(-3, this.gameObject.transform.position.y, -11);
                break;
            case 7:
                this.gameObject.transform.position = new Vector3(1, this.gameObject.transform.position.y, -11);
                break;
            case 8:
                this.gameObject.transform.position = new Vector3(5, this.gameObject.transform.position.y, -11);
                break;
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

