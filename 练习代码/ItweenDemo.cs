using UnityEngine;
using System.Collections;

public class ItweenDemo : MonoBehaviour {

    public GameObject g;
    Hashtable h = new Hashtable();
	// Use this for initialization
    void Awake()
    {
        g = GameObject.Find("Cube 1");
        h.Add("position",new Vector3(10, 0, 10));
        h.Add("time", 20f);
        h.Add("speed", 0.5);

    }
	void Start () {

        //iTween.MoveTo(this.gameObject,h);
       // iTween.FadeTo(g, 0.3f, 0.3f);
        iTween.LookTo(g, Vector3.back, 7f);
	}
	
	// Update is called once per frame
	void Update () {
	
       
	}
}
