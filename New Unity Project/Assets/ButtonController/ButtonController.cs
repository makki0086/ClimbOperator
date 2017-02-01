using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : BaseButtonController
{
    public Bar HP;

    public float speed;
    void Awake()
    {
        speed = 0.00084f;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HP.ReduceFrom(speed);
    }

    protected override void OnClick(string ObjectName)
    {
        switch (ObjectName)
        {
            case "Button":
                speed = 0.01f;
                //HP.ReduceFrom();
                Debug.Log("aa");
                break;
            case "Button (1)":
                Debug.Log("bb");
                HP.GainFrom(1.0f, (Bar sender) => {
                    Debug.Log("animation finish!!");
                });
                break;
           
            default:
                break;
        }
       // base.OnClick(ObjectName);
       //if("".Equals(ObjectName))
       // {

       // }

    }
}
