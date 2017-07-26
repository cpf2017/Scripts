using UnityEngine;
using System.Collections;

public class WenZi : MonoBehaviour {

    public GameObject g;
    UITextList t;
    UILabel l;
   // public UILabel L;
    //public UITextList T;
    //public string C;
	// Use this for initialization
	void Start () {
        l = g.GetComponent<UILabel>();
        t = GetComponent<UITextList>();
       // L = GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            t.Add(l.text);
        }

       // T.Add(C);
	}
}
