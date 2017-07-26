using UnityEngine;
using System.Collections;

public class ShiJian : MonoBehaviour {

    AnimationEvent m;  //声明要添加的事件
    public AnimationClip c; //要添加事件的动画
    public GameObject T;   //特效预制体
    public Transform TS;   //特效的挂载点
	// Use this for initialization
	void Start () {
        AddEvent();
       // this.GetComponent<Animator>().Rebind();
	}
	
	// Update is called once per frame
	void Update () {

       // AddEvent();
	}

    private void AddEvent()
    {
        m = new AnimationEvent();
       // m.time = 1f;
        m.functionName = "Skill";
        c.AddEvent(m);
    }

    public void Skill()
    {
            Instantiate(T, TS.position, TS.rotation);
    }

}
