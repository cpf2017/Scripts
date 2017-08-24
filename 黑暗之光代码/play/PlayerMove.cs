using UnityEngine;
using System.Collections;


public enum PlayerState //角色状态
{
    Moving,
    Idle

}
public class PlayerMove : MonoBehaviour {


    public float speed = 4; //记录速度
    public PlayerState state = PlayerState.Idle; //存储角色状态，默认为停止状态
    private PlayerDir dir; //引用PlayerDir这个类，从里面获取目标位置
    private CharacterController controller; //用这个控制器来控制移动
    public bool isMoving = false;

	// Use this for initialization
	void Start () {
	
        dir = this.GetComponent<PlayerDir>();
        controller = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(dir.targetPosition, transform.position); //当前位置和目标位置的距离
        if (distance > 0.1f) //判断角色到没到目标位置
        {
            isMoving = true;
            state = PlayerState.Moving;
            controller.SimpleMove(transform.forward * speed); //向前移动
        }
        else
        {
            isMoving = false;
            state = PlayerState.Idle;
        }
	}
}
