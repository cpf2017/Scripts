using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public CharacterController player;
    public float vy = 0;

    public float gravity = -2;
    //摄像机与主角高度差
    public float cmHeight = 1.3f;
    public float speed = 0.1f;
    public Camera camera; //声明摄像机变量
	void Start () {
        //获得摄像机
        camera = Camera.main;
	}
	void Update () {

        PlayerMoveDemo();
        CameraControl();
	}
    #region 摄像机视角旋转
    private void CameraControl()
    {
       //camera.transform.eulerAngles = new Vector3(45, 0, 0);
        //获取摄像机欧拉角
        Vector3 cmEuler = camera.transform.eulerAngles;
        cmEuler.y += Input.GetAxis("Mouse X");
        cmEuler.x -= Input.GetAxis("Mouse Y");
        camera.transform.eulerAngles = cmEuler;
        //同步主角的欧拉角
        cmEuler.x = cmEuler.z = 0;
        this.transform.eulerAngles = cmEuler;
        //摄像机的跟随
        camera.transform.position = this.transform.position + new Vector3(0, cmHeight, 0);
    }
    #endregion

    #region 控制主角移动
    public void PlayerMoveDemo()
    {
        float vx = Input.GetAxis("Horizontal");  //水平方向
        float vz = Input.GetAxis("Vertical");    //纵轴方向
        //垂直方向
        vy += gravity;

        //跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vy = 30;
        }
        //控制主角移动
        player.Move(player.transform.TransformDirection(new Vector3(vx, vy, vz) * speed));
    }
    #endregion
}
