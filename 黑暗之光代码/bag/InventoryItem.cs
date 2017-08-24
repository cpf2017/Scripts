using UnityEngine;
using System.Collections;

public class InventoryItem : UIDragDropItem
{ //要实现拖拽只用继承UIDragDropItem类就可以了，注意把Strt和Update方法删除，要想使用需要base.Start才可以


    private UISprite sprite;
    private int id;
    void Awake()
    {
        sprite = this.GetComponent<UISprite>();
    }


    void Update()
    {
        if (isHover)//显示提示信息
        {
            InventoryDes._instance.Show(id);
        }
    }
    protected override void OnDragDropRelease(GameObject surface)  //当拖拽结束时会调用这个方法，参数就是鼠标下的物体，用来判断是否拖拽到了网格里。
    {
        base.OnDragDropRelease(surface);
        if (surface != null)
        {
            if (surface.tag == Tags.inventory_item_grid) //当物品拖放到了一个格子里面
            {
                if (surface == this.transform.parent.gameObject)//拖放到了自己的格子里面
                {
                   
                }
                else //拖放到一个空格子里
                {
                    InventoryItemGrid oldParent = this.transform.parent.GetComponent<InventoryItemGrid>();
   
                    this.transform.parent = surface.transform;
                    InventoryItemGrid nowparent = this.transform.parent.GetComponent<InventoryItemGrid>();
                    nowparent.SetId(oldParent.id, oldParent.num); //把信息放到拖放到的这个新格子里
                    oldParent.ClearInfo(); //清除原有格子的信息
      
                }

            }
            else if (surface.tag == Tags.inventroy_item)//当拖放到了一个有其他物品的格子里面
            {
                InventoryItemGrid grid1 = this.transform.parent.GetComponent<InventoryItemGrid>();//得到当前格子
                InventoryItemGrid grid2 = surface.transform.parent.GetComponent<InventoryItemGrid>();//得到另外一个格子
                int id = grid1.id;  //存储当前格子物品id
                int num = grid1.num;  //存储当前格子物品数量
                grid1.SetId(grid2.id, grid2.num); //把第二个格子里的物品id个物品数量给第一个格子
                grid2.SetId(id, num); //把当前格子信息给第一个格子
            }
        }
        ResetPosition();
    }


    void ResetPosition()
    {
        transform.localPosition = Vector3.zero; //将物品放到格子中间
    }

    public void SetId(int id) 
    {
        //根据id显示物品信息
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        sprite.spriteName = info.icon_name; //根据info来更新物品显示
    }

    public void SetIconName(int id, string icon_name)
    {
        this.id = id;
        sprite.spriteName = icon_name;
        
    }

    private bool isHover = false;
    public void OnHoverOver() //鼠标移到物品上
    {
        isHover = true;
    }
    public void OnHoverOut() //鼠标移开物品
    {
     
        isHover = false;
    }
}
