using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {


    public float tumble = 5f;

	void Start () {
        this.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	
	}
	
	
}
