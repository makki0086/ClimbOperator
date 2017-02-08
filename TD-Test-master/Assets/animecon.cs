using UnityEngine;
using System.Collections;

public class animecon : MonoBehaviour {
    [SerializeField]
    private GameObject BatteryUI;
    private UISelector selector;
    private Animator anim;
    // Use this for initialization
    void Start () {
        selector = BatteryUI.GetComponent<UISelector>();
        anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(selector.Battery_Slider.value>=0)
        {
            anim.speed = 1.0f;
        }
        if(selector.Battery_Slider.value <= 0)
        {

            anim.speed = 0.5f;
        }
    }
}
