﻿using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private float speed;
    private float speed_tmp;

    private GameObject m_player;
    // Use this for initialization
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        speed = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_player.transform.position.y+45.0f>this.gameObject.transform.position.y)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - speed, this.gameObject.transform.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Floor")
        {
            Destroy(this.gameObject);
        }

        if(collision.transform.tag=="Obstacle")
        {
            Destroy(this.gameObject);
        }

        if(collision.transform.tag=="Player")
        {
            this.speed_tmp = this.speed;
            this.speed = 0;
            //Destroy(this.gameObject);
        }
    }
    //オブジェクトが離れた時
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {

            this.speed = this.speed_tmp;
            //Destroy(this.gameObject);
        }
    }

    public float Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            this.speed = value;
        }
    }
}