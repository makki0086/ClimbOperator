using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーコントローラー
/// </summary>
public class PlayerController : MonoBehaviour {
    PlayerPositionCounter c;
    
    // Use this for initialization
	void Start () {


        c = new PlayerPositionCounter();

	}
	
	// Update is called once per frame
	void Update () {
        c.PositionCount = c.PositionCount + 1;
        Debug.Log(c.PositionCount);
        
	}


}

class PlayerPositionCounter
{
    //プレイヤーポジションカウント
    private int PlayerPositionCount = 1;

    public int PositionCount
    {
        get
        {
            return PlayerPositionCount;
        }
        set
        {
            if ((value > 0) && (value < 9))
            {
                PlayerPositionCount = value;
            }
        }
    }

}
