using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    private GameOver gameover;
    private AngleManager angle;
    //! タッチした場所
    private Vector3 start_Pos;

    private Vector3 intermediate_Pos;
    //! 離した場所
    private Vector3 end_Pos;
    //! タッチした？
    private bool isTouch;

    private bool iseffectTouch;

    [SerializeField]
    Camera cam;
    [SerializeField]
    GameObject CLICK_PARTICLE;

    private GameObject m_ClickParticle;

    private ParticleSystem m_ClickParticleSystem;

    //  public static TouchMode mode;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController=player.GetComponent<PlayerController>();
        gameover = player.GetComponent<GameOver>();
        angle = this.GetComponent<AngleManager>();
    }

	// Use this for initialization
	void Start ()
    {
        m_ClickParticle = (GameObject)Instantiate(CLICK_PARTICLE);
        m_ClickParticleSystem = m_ClickParticle.GetComponent<ParticleSystem>();
        m_ClickParticleSystem.Stop();
        isTouch = false;
        iseffectTouch = false;
    //    mode = TouchMode.Swaipe;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!gameover.IsGameOver)
        if (iseffectTouch)
        {
               // Vector3 pos = intermediate_Pos;
          //  Vector3 pos = cam.ScreenToWorldPoint(intermediate_Pos + cam.transform.forward * 10);
                //    Vector3 mousePosition = intermediate_Pos;
                //mousePosition =mousePosition+ cam.transform.forward*10;
                //mousePosition = cam.ScreenToWorldPoint(mousePosition);
                //m_ClickParticle.transform.position = mousePosition;
                //m_ClickParticleSystem.Play();
                //    mousePosition.z = 20f;
                //    // mousePosition.z = -40f;
                //    //mousePosition.x = -40f;// ※Canvasよりは手前に位置させること
                //    mousePosition = cam.ScreenToWorldPoint(mousePosition);
              //  m_ClickParticleSystem.Emit(1);
               // m_ClickParticle.transform.position = pos;
          
            //  //  mousePosition.x=mousePosition.x - 40;
            //    //mousePosition.z = mousePosition.z - 40;
            //   // m_ClickParticle.transform.position = mousePosition;
            //    m_ClickParticleSystem.Play();

        }
            else
            {
                m_ClickParticleSystem.Stop();
            }

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

                case AngleManager.Angle_Value.UPPER_RIGHT:
                    playerController.Skill2();
                    break;
                case AngleManager.Angle_Value.UPPER_LEFT:
                    playerController.Skill3();
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
    public Vector3 IntermediatePosition
    {
        get
        {
            return intermediate_Pos;
        }
        set
        {
            intermediate_Pos = value;
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
    public bool IsEffectTouch
    {
        get
        {
            return iseffectTouch;
        }
        set
        {
            iseffectTouch = value;
        }
    }
}
// public enum TouchMode
  //  {
        
  //      Touch,
  //      Swaipe,
//}