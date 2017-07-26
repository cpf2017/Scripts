using UnityEngine;
using System.Collections;

public class inputdemo : MonoBehaviour {

	// Use this for initialization
    public GameObject go;
    UIInput input;
    UITextList list;
	void Start () {
	   input = GetComponent<UIInput>();
       EventDelegate.Add(input.onSubmit,ffff);
        list = go.GetComponent<UITextList>();
	}
    void ffff()
    {
        list.Add(input.value);
    }
}

