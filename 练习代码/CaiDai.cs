using UnityEngine;
using System.Collections;

public class CaiDai : MonoBehaviour {

    private TweenPosition p;
    private bool isShow = false;
	// Use this for initialization
	void Start () {
	
        //p = this.gameObject.GetComponent<TweenPosition>();
        p = GameObject.Find("GuDai").GetComponent<TweenPosition>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TransformMenu()
    {
        if (isShow == false)
        {
            p.PlayForward();
            isShow = true;
        }
        else
        {
            p.PlayReverse();
            isShow = false;
        }
    }
}
