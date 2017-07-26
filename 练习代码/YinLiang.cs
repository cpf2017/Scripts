using UnityEngine;
using System.Collections;

public class YinLiang : MonoBehaviour {

    public GameObject g;
    public UISlider l;
    public AudioSource d;
	// Use this for initialization
	public  void Start () {

        float s = g.GetComponent<UISlider>().value;
        d.volume = s;
  
	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
