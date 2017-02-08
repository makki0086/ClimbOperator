using UnityEngine;
using System.Collections;

public class PC_TouchManager : MonoBehaviour
{
    private TouchManager touch;

    //! マウスカーソルの場所
    private Vector3 mouse_Pos;
    void Awake()
    {
        touch = this.GetComponent<TouchManager>();
    }

    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        MousePositionUpdate();
        PC_Touch();
    }
    
    void MousePositionUpdate()
    {
        mouse_Pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
    }
    void PC_Touch()
    {
        touch.IntermediatePosition = mouse_Pos;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touch.StartPosition = mouse_Pos;
         //   if (TouchManager.mode == TouchMode.Touch)
          //  {
              //  touch.IsTouch = true;
          //  }
            // Debug.Log("mouse:start" + mouse_Pos);
            // Debug.Log("touch:start" + touch.StartPosition);
        }
        if(Input.GetMouseButtonDown(0))
        {
            touch.IntermediatePosition=mouse_Pos;
            touch.IsEffectTouch = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            touch.IsEffectTouch = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touch.EndPosition = mouse_Pos;
           // if (TouchManager.mode == TouchMode.Swaipe)
          //  {
                touch.IsTouch = true;
           // }
            
            //IsTouch = true;
            //Debug.Log("end" + endPos);
        }
    }
    //public Vector3 MousePosition
    //{
    //    get
    //    {
    //        return mouse_Pos;
    //    }
    //}
   
}
