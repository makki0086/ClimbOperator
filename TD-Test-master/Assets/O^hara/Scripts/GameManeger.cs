using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState
{
    PREPARATION,
    PLAY,
    PAUSE,
    GAMECLEAR,
    GAMEOVER
}

public class GameManeger : MonoBehaviour {

    public static GameState _State;
    [SerializeField]
    private GameObject TextObject;
    [SerializeField]
    private Text CountText;

    [SerializeField]
    private int Count = 5;

    // Use this for initialization
    void Start () {
        
        _State = GameState.PREPARATION;
        Debug.Log(_State);

	}
	
	// Update is called once per frame
	void Update () {
        if (_State == GameState.PREPARATION)
        {
            //if(1<Time.deltaTime())
            TextObject.SetActive(true);
            CountText.text = Count.ToString();
            Debug.Log(Count);
            Count -= 1;


            if (Count == 0)
            {
                _State = GameState.PLAY;
                Debug.Log(_State);
            }
        }
	}
}
