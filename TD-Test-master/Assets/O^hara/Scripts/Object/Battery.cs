using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            Destroy(this.gameObject);
        }

        if (collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
