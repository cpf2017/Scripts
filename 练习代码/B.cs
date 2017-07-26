using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class B : MonoBehaviour
{
    private InputField i;
    private InputField f;
    //Dictionary<string, string> registerMsg;
    //public Text S;
    private Button b;
    void Start()
    {

        i = GameObject.Find("InputField 1").GetComponent<InputField>();
        f = GameObject.Find("InputField 2").GetComponent<InputField>();
        // registerMsg = new Dictionary<string, string>();
        //S.text = string.Empty;
        b = GetComponent<Button>();
        b.onClick.AddListener(Example);
    }
    public void Example()
    {
        /*
        if (i.text != "" && f.text != "")
        {
            if (!PlayerPrefs.HasKey(i.text))
            {*/
        // registerMsg.Add(i.text, f.text);
        PlayerPrefs.SetString("hh", i.text);
        PlayerPrefs.SetString("tt", f.text);
        Application.LoadLevel(0);

        // i.text = string.Empty;
        //   }

        //  }

    }


}
