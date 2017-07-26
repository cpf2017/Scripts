using UnityEngine;
using System.Collections;

public class Script : MonoBehaviour
{

    public Animator a;

    // Use this for initialization
    void Start()
    {

        a = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (a)
        {
            AnimatorStateInfo ani = a.GetCurrentAnimatorStateInfo(0); //获取当前的动画层
            if (ani.IsName("New State"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    a.SetBool("r", true);
                    a.SetBool("w", true);
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    a.SetBool("d", true);
                    a.SetBool("e", true);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    a.SetBool("f", true);
                    a.SetBool("e", true);
                }
            }
            //判断当前层正在播放的动画的名字是否是idle
            if (ani.IsName("idle"))
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    a.SetBool("q", true);
                    a.SetBool("e", false);
                    a.SetBool("w", true);
                    // a.SetBool("goattack", false);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    a.SetBool("w", false);
                    a.SetBool("e", true);
                    a.SetBool("q", false);
                    //a.SetBool("go", false);
                }

            }

            if (ani.IsName("walk"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    a.SetBool("q", false);
                    a.SetBool("w", true);
                    a.SetBool("e", false);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    a.SetBool("e", true);
                    a.SetBool("w", false);
                    a.SetBool("q", true);
                    //a.SetBool("goattack", false);
                }

            }
            if (ani.IsName("attack1"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    a.SetBool("w", true);
                    a.SetBool("q", false);
                    a.SetBool("e", true);
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    a.SetBool("e", false);
                    a.SetBool("q", true);
                    a.SetBool("w", false);
                }

            }

        }
    }
}
