using UnityEngine;
using System.Collections;


public class SmartPhone_TouchManager : MonoBehaviour
{

    private TouchManager touchManager;

    private Touch touch;

   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SmartPhone_Touch();
        //debagtext.text = "count:" + Input.touchCount + "touches" + Input.touches[0];
    }

    void SmartPhone_Touch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.touches[0];
           
            switch (touch.phase)

            {

                case TouchPhase.Began:

                    touchManager.StartPosition = touch.position;
                    if(TouchManager.mode==TouchMode.Touch)
                    {
                        touchManager.IsTouch = true;
                    }
                    break;



                case TouchPhase.Ended:
                    touchManager.EndPosition = touch.position;
                    if (TouchManager.mode == TouchMode.Swaipe)
                    {
                        touchManager.IsTouch = true;
                    }
                    
                    break;
            }

        }
    }
}
