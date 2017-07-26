using UnityEngine;
using System.Collections;

public class Tiao : MonoBehaviour {

    private NavMeshAgent a;
    GameObject t;

	// Use this for initialization
	void Start () {

        a = GetComponent<NavMeshAgent>();
        t = GameObject.Find("Start");
	
	}
	
	// Update is called once per frame
	void Update () {

        a.SetDestination(t.transform.position);
	}
}
