using UnityEngine;
using System.Collections;

public class CD : MonoBehaviour {

    public float cdtime = 5;
    private bool iscoid = false;
    private UISprite s;
	// Use this for initialization
	void Start () {

        s = transform.Find("cd").GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Q) && iscoid == false) 
        {
            s.enabled = true;
            s.fillAmount = 1;
            iscoid = true;
        }

        if (iscoid)
        {
            s.fillAmount -= (1 / cdtime) * Time.deltaTime;
            if (s.fillAmount <= 0.02)
            {
                s.fillAmount = 0;
                iscoid = false;
            }
        }
	}
}
