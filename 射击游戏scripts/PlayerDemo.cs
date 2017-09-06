using UnityEngine;
using System.Collections;

public class PlayerDemo : MonoBehaviour {


    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void Update()
    {

    }
}
