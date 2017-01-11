using UnityEngine;
using System.Collections;

public class TitlePlayer : MonoBehaviour {
    private Vector3 speed;
	// Use this for initialization
	void Start () {
        speed = new Vector3(0.02f, 0, 0);
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += speed;
        if(transform.localPosition.x>=6.0f)
        {
            speed = new Vector3(-0.02f, 0, 0);
            
        }

        if (transform.localPosition.x <= -6.0f)
        {
            speed = new Vector3(0.02f, 0, 0);
        }

    }
}
