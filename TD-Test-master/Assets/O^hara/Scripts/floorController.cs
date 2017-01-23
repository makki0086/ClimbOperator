using UnityEngine;
using System.Collections;

public class floorController : MonoBehaviour {

    public float ScrollSpeed = 0.2f;
    private MeshRenderer mr;
    float d;
    float offset = 0f;

    // Use this for initialization
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        d +=Time.deltaTime;
        if (1 < d)
        {
            d = 0;
            int r = Random.Range(0, 3 + 1);
            if (r == 0)
            {
                offset = Mathf.Repeat(Time.time * ScrollSpeed, 1f);
                offset = 1f - offset; //逆向きに動かしたい場合
                mr.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
            }
            if (r == 1)
            {
                offset = Mathf.Repeat(Time.time * ScrollSpeed, 1f);
                // offset = 1f - offset; //逆向きに動かしたい場合
                mr.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
            }

            if (r == 2)
            {
                offset = Mathf.Repeat(Time.time * ScrollSpeed, 1f);
                offset = 1f - offset; //逆向きに動かしたい場合
                mr.material.SetTextureOffset("_MainTex", new Vector2(offset,0f));
            }
            if (r == 3)
            {
                offset = Mathf.Repeat(Time.time * ScrollSpeed, 1f);
                // offset = 1f - offset; //逆向きに動かしたい場合
                mr.material.SetTextureOffset("_MainTex", new Vector2(offset,0f));
            }
        }
    }
}
