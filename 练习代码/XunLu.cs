using UnityEngine;
using System.Collections;

public class XunLu : MonoBehaviour
{

    private NavMeshAgent a;
    private GameObject g;
    // Use this for initialization
    void Start()
    {

        a = GetComponent<NavMeshAgent>();
        g = GameObject.Find("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                if (h.collider.tag == "Plane" )
                {
                    a.destination = h.point;
                }
            }
        }
    }
}
