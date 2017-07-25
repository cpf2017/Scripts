using UnityEngine;
using System.Collections;

public class DestroyByBoudary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
