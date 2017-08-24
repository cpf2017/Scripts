using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

    public static Status _instance;
    private TweenPosition tween;
    private bool isShow = false;
    
    //任务属性面板的引用
    private UILabel attackLabel;
    private UILabel defLabel;
    private UILabel speedLabel;
    private UILabel pointRemainLabel;
    private UILabel summaryLabel;

    private GameObject attackButtonGo;
    private GameObject defButtonGo;
    private GameObject speedButtonGO;

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();//获取动画组件

        attackLabel = transform.Find("attack").GetComponent<UILabel>();
        defLabel = transform.Find("def").GetComponent<UILabel>();
        speedLabel = transform.Find("speed").GetComponent<UILabel>();
        pointRemainLabel = transform.Find("pointRemain").GetComponent<UILabel>();
        summaryLabel = transform.Find("summary").GetComponent<UILabel>();

        attackButtonGo = transform.Find("attack_plusbutton").gameObject;
        defButtonGo = transform.Find("def_plusbutton").gameObject;
        speedButtonGO = transform.Find("speed_plusbutton").gameObject;

        
    }

    public void TransformState()
    {
        if (isShow == false)  //动画隐藏状态，播放动画，显示动画
        {
            tween.PlayForward(); isShow = true;
        }
        else //动画显示状态，隐藏动画往回播放，
        {
            tween.PlayReverse(); isShow = false;
        }
    }
}
