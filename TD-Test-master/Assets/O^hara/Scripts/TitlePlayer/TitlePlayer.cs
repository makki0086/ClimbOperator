using UnityEngine;
using System.Collections;
//enum Action
//{
//    None,         //! 何もしていない
//    CentralAppeal,//! 中央でアピール
//    LeftAppeal,   //! 左でアピール
//    RightAppeal,  //! 右でアピール
//    LeftMove,     //! 左へ移動
//    RightMove     //! 右へ移動
//}
public class TitlePlayer : MonoBehaviour {

    private Vector3 movespeed;
    private Vector3 leftmovespeed;
    private Vector3 rightmovespeed;

    private Vector3 rotationspeed;

    //! 過去のアクション
   // private Action pastAction;
    //! 現在のアクション
    //private Action currentAction;

    
    // Use this for initialization
    void Start () {
       // InitializeAction(Action.None, Action.None);
        leftmovespeed= new Vector3(-0.02f, 0, 0);
        rightmovespeed= new Vector3(0.02f, 0, 0);
        movespeed = new Vector3(0, 0, 0);
        //rotationspeed=new Vector3
    }
	
	// Update is called once per frame
	void Update () {
        //if(transform.localPosition.x==0)
        //{
        //    if(pastAction==Action.None&&currentAction==Action.None)
        //    {
        //        UpdateAction(currentAction, Action.CentralAppeal);
        //      //  Debug.Log("aaaaaaaaaa");
        //    }

        //    if(currentAction==Action.CentralAppeal&&pastAction==Action.None)
        //    {
        //        if(transform.localEulerAngles.y<=90)
        //        {
        //            UpdateAction(currentAction, Action.RightMove);
        //            movespeed = rightmovespeed;
        //        }
        //        else
        //        {
        //            Vector3 leax = transform.localEulerAngles;
        //            leax.y += -20.0f*Time.deltaTime;
        //            transform.localEulerAngles = leax;                    
        //        }
        //        //transform.Rotate(new Vector3(0, -1, 0), 90);
                
        //    }
        //}
        //if(transform.localPosition.x>=3)
        //{
        //    //if()
        //}

        //transform.localPosition += movespeed*Time.deltaTime;
      //  if()

        //if(transform.localPosition.x>=6.0f)
        //{
        //    movespeed = new Vector3(-0.02f, 0, 0);
        //  //  transform.localRotation
        //}

        //if (transform.localPosition.x <= -6.0f)
        //{
        //    movespeed = new Vector3(0.02f, 0, 0);
        //}

    }
    /// <summary>
    /// アクションの初期化
    /// </summary>
  //  private void InitializeAction(Action _pastAction,Action _currentAction)
 //   {
 //       pastAction = _pastAction;
 //       currentAction = _currentAction;
  //  }
    /// <summary>
    /// アクションの更新
    /// </summary>
//    private void UpdateAction(Action _currentAction,Action _nextAction )
//    {
 //       pastAction = _currentAction;
 //       currentAction = _nextAction;
        
//    }
}
