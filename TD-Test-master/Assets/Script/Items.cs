using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour 
{
	[SerializeField]
	private Transform[] m_Object;
    private GameObject m_Floor;
    private bool m_Pausing;
    Vector3 localGravity;
    private float speed;
    // Use this for initialization
    void Start () 
	{
        speed = 3.0f;
        m_Floor = GameObject.FindGameObjectWithTag("Floor");
        //localGravity = new Vector3(0, 8.0f, 0);
        // this.gameObject.GetComponent<Rigidbody>().AddForce(localGravity, ForceMode.Acceleration);
    }

	// Update is called once per frame
	void Update () 
	{
        if(m_Floor.transform.position.y > this.gameObject.transform.position.y+20)
        {
            Destroy(this.gameObject);
        }   

            //Vector3 pos = this.gameObject.transform.position;
            //pos.y -= speed;
            //this.gameObject.transform.position = pos;

        }

	void OnCollisionEnter(Collision collision)
	{
		m_Pausing = GameObject.Find("Player").GetComponent<GameOver>().pausing;

		if (m_Pausing == false) 
		{
			if (collision.transform.tag == "Floor") 
			{
				Destroy (gameObject);
			}
			if (collision.transform.tag == "Player" && transform.tag == "battery") 
			{
				Destroy (gameObject);
			}
			if (collision.transform.tag == "Stone" && transform.tag == "Stone") 
			{
				Destroy (gameObject);
			}
			if (collision.transform.tag == "Stone" && transform.tag == "battery") 
			{
				Destroy (gameObject);
			}
		}
	}

}
