using UnityEngine;
using System.Collections;

//任务面板操作
public class BarNPC : NPC {

    public TweenPosition questTween; //持有动画组件
    public UILabel desLabel;
    public GameObject acceptBtnGo;  
    public GameObject okBtnGo;
    public GameObject cancelBtnGo;

    public bool isInTask = false; //是否在任务中
    public int killCount = 0; //表示任务进度，已经杀死了几小野狼

    private PlayerStatus status;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }
    void OnMouseOver() //当鼠标位于这个collider之上的时候，会在每一帧调用这个方法
    {
        if (Input.GetMouseButtonDown(0)) //当点击了老爷爷
        {
            if (isInTask)
            {
                ShowTaskProgress();
            }
            else
            {
                ShowTaskDes();
            }
            ShowQuest();
        }
    }

    void ShowQuest()
    {
        questTween.gameObject.SetActive(true); //显示任务面板
        questTween.PlayForward(); //播放动画
    }


    void HideQuest()
    {
        questTween.PlayReverse(); //向后播放动画
    }

    void ShowTaskDes() //显示任务描述
    {
        desLabel.text = "任务：\n你杀死了10只狼\n\n奖励：\n1000金币";
        okBtnGo.SetActive(false);
        acceptBtnGo.SetActive(true);
        cancelBtnGo.SetActive(true);
    }
    void ShowTaskProgress() //显示任务进度
    {
        desLabel.text = "任务：\n你已经杀死了" + killCount + "\\10只狼\n\n奖励：\n1000金币";
        okBtnGo.SetActive(true);
        acceptBtnGo.SetActive(false);
        cancelBtnGo.SetActive(false);
    }

    //任务对话框上的按钮事件处理
    public void OnCloseButtonClick()
    {
        HideQuest();
    }

    public void OnAcceptButtonClick()
    {
        ShowTaskProgress();
        isInTask = true; //表示在任务中
    }

    public void OnOkButtonClick()
    {
        if (killCount >= 10) //完成任务
        {
            status.GetCoint(1000); //完成任务
            killCount = 0; //将任务归0
            ShowTaskDes(); //重新开启任务
        }
        else  //没有完成任务
        {
            HideQuest(); 
        }
    }

    public void OnCancelButtonClick() //隐藏对话框
    {
        HideQuest(); 
    }
}
