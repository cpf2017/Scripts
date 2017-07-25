using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float scrollSpead;
    public float tileSizeZ;


    private Vector3 startPosition;

    void Start()
    {
        startPosition = this.transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpead, tileSizeZ);
        this.transform.position = startPosition + Vector3.forward * newPosition;
    }
}
