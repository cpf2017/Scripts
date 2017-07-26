using UnityEngine;
using System.Collections;

public class ShanChu : MonoBehaviour {

    UIInput u;
	// Use this for initialization
	void Start () {
	
        u = GetComponent<UIInput>();
	}
	
	// Update is called once per frame
    public void T()
    {
        Invoke("F", 0.1f);
    }
    public void F()
    {
        u.value = null;
    }
}
