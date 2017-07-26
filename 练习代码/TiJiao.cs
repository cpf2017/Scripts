using UnityEngine;
using System.Collections;

public class TiJiao : MonoBehaviour {

    public GameObject g;
    UIInput u;
    UITextList l;
 
	// Use this for initialization
	void Start () {
	
        u = GetComponent<UIInput>();
        //EventDelegate.Add(Input.);
        EventDelegate.Add(u.onSubmit,Ti);
        l =g.GetComponent<UITextList>();
        //d = GetComponent<UIGrid>();
	}


    void Ti()
    {
        l.Add(u.value);
    }
    public void T()
    {
        Invoke("F", 0.1f);
    }
    public void F()
    {
        u.value = null;
    }
}
