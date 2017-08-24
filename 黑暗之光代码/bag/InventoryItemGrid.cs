using UnityEngine;
using System.Collections;


//管理背包方格
public class InventoryItemGrid : MonoBehaviour {

    public int id = 0;  //当前存储物品的id，默认为0，就是没有物品
    private ObjectInfo info = null; //物品信息
    public int num = 0;  //有多少个物品

    private UILabel numLabel; //角标数字
	// Use this for initialization
	void Start () {

        numLabel = this.GetComponentInChildren<UILabel>(); //获取数字

	}


    public void SetId(int id, int num = 1)  //设置网格，当往背包网格里放东西的时候就调用此方法
    {
        this.id = id;
        info = ObjectsInfo._instance.GetObjectInfoById(id);  //得到物品信息
        InventoryItem item = this.GetComponentInChildren<InventoryItem>(); //获取InventoryItem脚本
        item.SetIconName(id,info.icon_name);  //调用InventoryItem类里面的方法，更新物品的显示
        print(id);
        print(info.icon_name);
        numLabel.enabled = true;//启用number
        this.num = num; //更新数字
        numLabel.text = num.ToString(); //更新他的显示
    }


    public void PlusNumber(int num = 1) //背包里存在物品时，在放入同样物品数量加一
    {
        this.num += num;
        numLabel.text = this.num.ToString();//更新数字显示
    }
    public void ClearInfo() //当物品移走，清空背包网格物品信息
    {
        id = 0;
        info = null;
        num = 0;
        numLabel.enabled = false;
    }
}
