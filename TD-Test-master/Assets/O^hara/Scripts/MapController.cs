using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {
    public GameObject[] pil;
    private GameObject m_Floor;
    public  GameObject[] pilji;

    // Use this for initialization
    void Start () {
        m_Floor = GameObject.FindGameObjectWithTag("Floor");


    }

    // Update is called once per frame
    void Update() {


        if (this.gameObject.tag == "Pillar")
        {
            if (m_Floor.transform.position.y > this.gameObject.transform.position.y + 55)
            {
                Vector3 pos = this.gameObject.transform.position;
                // Destroy(this.gameObject);
                pos.y += 116;
                //this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.transform.position.y+116, this.gameObject.transform.position.z);
                //pil.tag = "Pillar";
                //GameObject gg = pil[Random.Range(0, 2)];
                int random = Random.Range(0,pil.Length);
                GameObject GO = Instantiate(pil[random], pos, Quaternion.identity) as GameObject;
                GO.name = pil[random].gameObject.name;
                Destroy(this.gameObject);
            }
        }

        if (this.gameObject.tag == "Pillarjoint")
        {
            if (m_Floor.transform.position.y > this.gameObject.transform.position.y + 20)
            {
                Vector3 pos = this.gameObject.transform.position;
                // Destroy(this.gameObject);
                pos.y += 116;
                int i = 0;
                // this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 116, this.gameObject.transform.position.z);
                GameObject GO = Instantiate(pilji[i], pos, Quaternion.identity) as GameObject;
                GO.name = this.gameObject.name;
                Destroy(this.gameObject);
            }
        }


    }
   
}


