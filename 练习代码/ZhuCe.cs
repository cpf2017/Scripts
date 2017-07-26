using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ZhuCe : MonoBehaviour {

    private Button b;
	// Use this for initialization
	void Start () {
	
        b = this.GetComponent<Button>();
        b.onClick.AddListener(Show);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Show()
    {
        Application.LoadLevel(1);
    }
}
