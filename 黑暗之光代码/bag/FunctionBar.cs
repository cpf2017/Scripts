using UnityEngine;
using System.Collections;

public class FunctionBar : MonoBehaviour {

    public void OnStatusButtonClick()
    {

    }
    public void OnBagButtonClick()
    {
        Inventory._instance.TransformState();
    }
    public void OnEquipButtonClick()
    {

    }
    public void OnSkillButtonClick()
    {

    }
    public void OnSttingButtonClick()
    {

    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.X)) //没按下x就拾取了物品
    //    {
    //        Inventory._instance.GetId(Random.Range(1001, 1004)); //随机拾取了物品id
    //    }
    //}
}
