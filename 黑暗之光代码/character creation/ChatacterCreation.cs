using UnityEngine;
using System.Collections;

public class ChatacterCreation : MonoBehaviour {

    public GameObject[] characterPrefabs; //定义一个数组存储所需要的角色
    public UIInput nameInput; //用来得到输入的文本 
    private GameObject[] characterGameObjects; //将实例化的角色存入另一个数组
    private int selectedIndex = 0; //当前默认选择的是那一个角色
    private int length; //所有可供选择的角色的个数

	// Use this for initialization
	void Start () {
        length = characterPrefabs.Length; 
        characterGameObjects = new GameObject[length]; //构造数组将角色个数放入数组
        for (int i = 0; i <length; i++)
        {
            characterGameObjects[i] = GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation) as GameObject;
        }

        UpdateCharacterShow();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateCharacterShow()  //更新所有角色的显示
    {
        characterGameObjects[selectedIndex].SetActive(true);
        for (int i = 0; i < length; i++)
        {
            if (i != selectedIndex)
            {
                characterGameObjects[i].SetActive(false); //把为选择的角色设置为隐藏
            }
        }
    }

    public void OnNextButtonClick()  //当我们点击了下一个按钮
    {
        selectedIndex++;  
        selectedIndex %= length; //点击按钮时让角色循环显示
        UpdateCharacterShow();
    }
    public void OnPrevButtonClick()  //当我们点击了上一个按钮
    {
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length - 1;
          
        }
        UpdateCharacterShow();
    }

    public void OnOkButtonClick()
    {
        PlayerPrefs.SetInt("SelectedCharaterIndex", selectedIndex); //存储选择的角色
        PlayerPrefs.SetString("name", nameInput.value); //存储输入的名字
        //加载下一个场景
    }
}
