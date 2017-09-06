using UnityEngine;
using System.Collections;

public class ZomBie : MonoBehaviour {


    public UnityEngine.AI.NavMeshAgent agent;
    public PlayerMove player;

    public enum ActionType
    {
        IDLE,
        WALK,
        ATTACK,
        HIT,
        DIE
    }
    public ActionType _curActtionType;

    public AnimationClip curClip;
    #region 当前动作
    public ActionType CurActtionType
    {
        get { return _curActtionType; }
        set
        {
            _curActtionType = value;
            //声明动作名称
            string aniName = "";
            switch (_curActtionType)
            {
                case ActionType.IDLE:
                    aniName = "idle";
                    break;
                case ActionType.WALK:
                    aniName = "walk" + Random.Range(1, 3);
                    break;
                case ActionType.ATTACK:
                    aniName = "attack" + Random.Range(1, 3);
                    break;
                case ActionType.HIT:
                    aniName = "hit";
                    agent.speed = 0;
                    break;
                case ActionType.DIE:
                    aniName = "die";
                    break;
            }
            //获取当前动画片段
            curClip = ani.GetClip(aniName);
            //播放动画
            ani.CrossFade(aniName);
            //创建动画事件
            AnimationEvent ae = new AnimationEvent();
            ae.functionName = "ActionEnd";
            //制定回调参数
            ae.stringParameter = curClip.name;
            //制定回调时间
            ae.time = curClip.length -01f;
            //向动画片段添加事件
            curClip.AddEvent(ae);
            

        }
    }
    #endregion

    public Animation ani;
    //敌人和主角距离计算
    public float distance = 0;
    //敌人攻击的最小距离
    public float attackLength = 1.5f;
    //攻击等待时间
    public float attackWaitTime = 1f;
    //敌人移动速度
    public float moveSpeed = 1;

	void Start () {

        CurActtionType = ActionType.IDLE;
	}

    //动作结束是的回调方法
    public void ActionEnd(string clipName)
    {
        //Debug.Log(clipName + "结束了");
        //攻击是否结束
        if (clipName.Contains("attack"))
        {
            Invoke("ResetAction", attackWaitTime);
        }
        else if (clipName == "hit")
        {
            agent.speed = moveSpeed;
            CurActtionType = ActionType.IDLE;
        }
    }

    public void ResetAction()
    {
        //重置动作为等待
        CurActtionType = ActionType.IDLE;
    }
	void Update () {

        //agent.SetDestination(PlayerMove._instance.transform.position);
        //agent.SetDestination(player.transform.position);
        //agent.speed = 1.5f;



        distance = Vector3.Distance(this.transform.position, player.transform.position);

        if (CurActtionType == ActionType.IDLE)
        { 
            //敌人在主角附近
            if (distance <= attackLength)
            {
                //就攻击
                CurActtionType = ActionType.ATTACK;
                //停止寻路
                agent.ResetPath();
            }
            else //不在附近
            {
                //行走
                CurActtionType = ActionType.WALK;
                agent.speed = moveSpeed;
                agent.SetDestination(player.transform.position);
            }
        }

        //在行走过程
        if (CurActtionType == ActionType.WALK)
        {
            //
            if (distance <= attackLength)
            {
                agent.ResetPath();
                CurActtionType = ActionType.ATTACK;
            }
            else
            {
                CurActtionType = ActionType.WALK;
                agent.speed = moveSpeed;
                agent.SetDestination(player.transform.position);
            }
        }
        //攻击处理
        if (CurActtionType == ActionType.ATTACK)
        {

        }
        //被击中
        if (CurActtionType == ActionType.HIT)
        {

        }

        //死亡状态
        if (CurActtionType == ActionType.DIE)
        {

        }
	}
}
