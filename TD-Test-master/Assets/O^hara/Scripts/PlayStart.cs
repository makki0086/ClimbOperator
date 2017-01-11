using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // タッチ開始
                click();
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // タッチ移動
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // タッチ終了
            }
        }
    }

    public void click()
    {
        SceneManager.LoadScene("ModeSelect");
    }
}
