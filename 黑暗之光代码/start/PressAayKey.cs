using UnityEngine;
using System.Collections;

public class PressAayKey : MonoBehaviour {

    private bool isAnyDown = false;  //表示是否有任何按键按下
    private GameObject buttonContainer;
	// Use this for initialization
	void Start () {

        buttonContainer = this.transform.parent.Find("buttonContainer").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if (isAnyDown == false)  //还没有按键按下
        {
            if (Input.anyKey)  //只要有任何按键按下
            {
                //显示 button container
                //隐藏当前游戏物体
                //标记设为true
                ShowButton();
            }
        }
	}

    void ShowButton()
    {
        buttonContainer.SetActive(true);
        this.gameObject.SetActive(false);
        isAnyDown = true;
    }
}
