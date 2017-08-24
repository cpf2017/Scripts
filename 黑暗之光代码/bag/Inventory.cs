using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {

    public static Inventory _instance;
    public List<InventoryItemGrid> itemGridList = new List<InventoryItemGrid>();//List集合用来保存背包里所有的网格
      
    public UILabel cionNumberLabel; //金币的显示
    public GameObject inventoryItem; 

    private TweenPosition tween;  //引用动画
    private int coinCount = 1000; //金币数量
    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
        //tween.AddOnFinished(this.OnTweenPlayFinished); //监听动画的播放
        //this.gameObject.SetActive(false);  //将背包影藏
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) //没按下x就拾取了物品
        {
            GetId(Random.Range(1001, 1004)); //随机拾取了物品id
        }
    }

    //拾取到id的物品，并添加到物品栏里面
    //处理拾取物品的功能
    public void GetId(int id)
    {
        //在背包中查找是否有拾取到的物品
        InventoryItemGrid grid = null;
        foreach (InventoryItemGrid temp in itemGridList)
        {
            if (temp.id == id)  
            {
               
                grid = temp; break;
            }
        }
        if (grid != null) //存在物品的情况
        {
            grid.PlusNumber(); //如果存在物品，让num+1；
        }
        else   //不存在物品的情况
        {
            foreach (InventoryItemGrid temp in itemGridList)
            {
                if (temp.id == 0)
                {
                    grid = temp; break;
                }
            }
            if (grid != null) //如果不存在，查找空的方格，然后把拾取到的的物品放到方格中
            {
                GameObject itemGo = NGUITools.AddChild(grid.gameObject, inventoryItem);
                itemGo.transform.localPosition = Vector3.zero; //将物品放到方格中间
                itemGo.GetComponent<UISprite>().depth = 4;
                grid.SetId(id);
            }
        }

    }
    public bool isShow = false;
    //动画播放
    void Show()
    {
        isShow = true;
        //this.gameObject.SetActive(true); //开启beibao面板
        tween.PlayForward();
    }
    //动画回放
    void Hide()
    { 
        isShow = false;
        tween.PlayReverse();
    }

    //void OnTweenPlayFinished() 
    //{
    //    if (isShow == false)
    //    {
    //        this.gameObject.SetActive(false);
    //    }
    //}

    public void TransformState() //控制背包的显示影藏状态
    {
        if (isShow == false)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
}
