using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    private AngleManager angle;
    //! タッチした場所
    private Vector3 start_Pos;
    //! 離した場所
    private Vector3 end_Pos;
    //! タッチした？
    private bool isTouch;
  //  public static TouchMode mode;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController=player.GetComponent<PlayerController>();
        angle = this.GetComponent<AngleManager>();
    }

	// Use this for initialization
	void Start ()
    {

        isTouch = false;
    //    mode = TouchMode.Swaipe;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isTouch)
        {
            // switch(mode)
            //{
            //   case TouchMode.Touch:
            //if (start_Pos == end_Pos)
            //{
            //           if (Screen.height / 2 / 2 <= start_Pos.y)
            //           {

            //               Debug.Log("DD");

            //          }
            //          if(Screen.height/2>=start_Pos.y&&Screen.width/2<=start_Pos.x)
            //         {
            //              playerController.UP_Position();
            //          }
            //         if (Screen.height / 2 >= end_Pos.y && Screen.width / 2 >=start_Pos.x)
            ///         {
            //             playerController.DOWN_Position();
            //         }
            // }
            //     break;
            // case TouchMode.Swaipe:
            if (start_Pos == end_Pos)
            {


                
            }
            else
            {
                angle.Angle_calculation(start_Pos, end_Pos);
            }
            //    break;
            // }

            isTouch = false;

            //   }
            switch (angle.Angle)
            {
                case AngleManager.Angle_Value.UP:
                 //   if (Screen.height / 2 <= end_Pos.y && Screen.height / 2 <= start_Pos.y)
                 //   {
                        Debug.Log("DD");
                        playerController.Skill();
                  //  }
                    break;
                case AngleManager.Angle_Value.DOWN:
                   // if (Screen.height / 2 <= end_Pos.y && Screen.height / 2 <= start_Pos.y)
                    //{
                        Debug.Log("DD");
                   // }
                    break;
                case AngleManager.Angle_Value.RIGHT:
                    playerController.UP_Position();
                    break;
                case AngleManager.Angle_Value.LEFT:
                    playerController.DOWN_Position();
                    break;
                    
            }
            angle.AzimuthUpdate();
        }
	
	}

    public Vector3 StartPosition
    {
        get
        {
            return start_Pos;
        }
        set
        {
            start_Pos = value;
        }
    }
    public Vector3 EndPosition
    {
        get
        {
            return end_Pos;
        }
        set
        {
            end_Pos = value;
        }
    }

    public bool IsTouch
    {
        get
        {
            return isTouch;
        }
        set
        {
            isTouch = value;
        }
    }
}
// public enum TouchMode
  //  {
        
  //      Touch,
  //      Swaipe,
//}