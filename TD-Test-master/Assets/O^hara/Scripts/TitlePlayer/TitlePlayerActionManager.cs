using UnityEngine;
using System.Collections;

public class TitlePlayerActionManager : MonoBehaviour {
    private enum Action_List
    {
        None,         //! 何もしていない
        CentralAppeal,//! 中央でアピール
        LeftAppeal,   //! 左でアピール
        RightAppeal,  //! 右でアピール
        LeftMove,     //! 左へ移動
        RightMove     //! 右へ移動
    }
    private Action_List actionValue;
    //! 過去のアクション
    private Action_List pastAction;
    //! 現在のアクション
    private Action_List currentAction;


   /// <summary>
   /// アクションの初期化
   /// </summary>
   /// <param name="_pastAction"></param>
   /// <param name="_currentAction"></param>
    private void InitializeAction(Action_List _pastAction, Action_List _currentAction)
    {
        pastAction = _pastAction;
        currentAction = _currentAction;
    }
    /// <summary>
    /// アクションの更新
    /// </summary>
    /// <param name="_currentAction">現在のアクション</param>
    /// <param name="_nextAction">次のアクション</param>
    private void UpdateAction(Action_List _currentAction, Action_List _nextAction)
    {
        pastAction = _currentAction;
        currentAction = _nextAction;

    }

    //public Action_List Action
    //{
    //    get
    //    {
    //        return 
    //    }
    //}
}
