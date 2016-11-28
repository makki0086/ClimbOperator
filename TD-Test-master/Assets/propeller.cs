using UnityEngine;
using System.Collections;

public class propeller : MonoBehaviour {
    
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerControl.isbattery)
        {
            transform.Rotate(0, 0, 10);
        }
	}
}
