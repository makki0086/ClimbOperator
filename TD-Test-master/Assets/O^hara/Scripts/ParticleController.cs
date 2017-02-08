using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        //処理が終わったパーティクルは削除する。
        if (this.gameObject.GetComponent<ParticleSystem>().duration <= this.gameObject.GetComponent<ParticleSystem>().time)
        {
            Destroy(this.gameObject);
        }
    }
}