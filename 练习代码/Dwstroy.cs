using UnityEngine;
using System.Collections;

public class Dwstroy : MonoBehaviour {

    private float L = 2f;

	// Use this for initialization
	void Start () {

        Destroy(this.gameObject, L);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
