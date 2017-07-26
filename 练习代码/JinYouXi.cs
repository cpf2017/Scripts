using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class JinYouXi : MonoBehaviour {

    private Button b;
    private InputField i;
    private InputField f;
	// Use this for initialization
	void Start () {
	
        b = GetComponent<Button>();
        i = GameObject.Find("InputField").GetComponent<InputField>();
        f = GameObject.Find("InputField 1").GetComponent<InputField>();
        b.onClick.AddListener(Show);
	}

    public void Show()
    {
        if (i.text== PlayerPrefs.GetString("hh") && f.text==PlayerPrefs.GetString("tt"))
        {
            Application.LoadLevel(2);
        }
        else
        {
            print("傻");
        }
    }
}
