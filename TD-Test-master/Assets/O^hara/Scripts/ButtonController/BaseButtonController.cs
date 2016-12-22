using UnityEngine;
using System.Collections;

public class BaseButtonController : MonoBehaviour {
   
    public BaseButtonController button;
    
    void Awake()
    {
        
    }

    // Use this for initialization
	void Start ()
    {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if(button==null)
        {
            throw new System.Exception("Button instance is null!!");
        }

        button.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string ObjectName)
    {
        Debug.Log("Base Button");
    }
}
