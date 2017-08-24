using UnityEngine;
using System.Collections;

      //显示物品属性介绍
public class InventoryDes : MonoBehaviour {


    public static InventoryDes _instance;
    private UILabel label; //引用UILabel
    private float timer = 0;
    void Awake()
    {
        _instance = this;
        label = this.GetComponentInChildren<UILabel>();
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (this.gameObject.activeInHierarchy == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void Show(int id) // 显示描述
    {
        this.gameObject.SetActive(true);
        timer = 0.1f;
        transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);  //根据id得到物品信息
        string des = "";
        switch (info.type)
        {
            case ObjectType.Drug: //如果是Drug就
                des = GetDrugDes(info);  //从药品信息中取出需要的药品信息
                break;
        }
        label.text = des;
    }

    string GetDrugDes(ObjectInfo info)
    {
        string str = "";
        str += "名称：" + info.name + "\n";
        str += "+HP：" + info.hp + "\n";
        str += "+MP：" + info.mp + "\n";
        str += "出售价：" + info.price_sell + "\n";
        str += "购买价：" + info.price_buy;
        return str;
    }
}
