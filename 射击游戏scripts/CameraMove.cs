using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    private Transform player;
    private Vector3 offsetPosition; //位置偏移
    private bool isRotating = false; //判断鼠标是否滑动
    public float scrollSpeed = 10;
    public float rotateSpeed = 2;


    void Start()
    {

        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
    }
    void Update()
    { //处理视野的左右上下旋转
        RotateView();
    }
    //旋转
    void RotateView()
    {
        // Input.GetAxis("Mouse X"); //得到鼠标在水平方向的滑动
        // Input.GetAxis("Mouse Y"); //得到鼠标在垂直方向的滑动
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            transform.RotateAround(player.position, player.up, rotateSpeed * Input.GetAxis("Mouse X")); //左右旋转


            Vector3 orignalPos = transform.position;
            Quaternion originalRotation = transform.rotation;
            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));  //上下旋转，影响的属性有两个，一个是position,一个事rotation
            //限制y轴的旋转
            float x = transform.eulerAngles.x;

            if (x < 10 || x > 80) // 当超出范围之后，我们将属性归为原来的，就是让旋转无效
            {
                transform.position = orignalPos;
                transform.rotation = originalRotation;
            }
        }
    }
}
