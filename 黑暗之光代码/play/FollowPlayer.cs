using UnityEngine;
using System.Collections;

//相机跟随类
public class FollowPlayer : MonoBehaviour
{

    private Transform player;
    private Vector3 offsetPosition; //位置偏移
    private bool isRotating = false; //判断鼠标是否滑动

    public float distance = 0;  //摄像机到人物的长度
    public float scrollSpeed = 10;
    public float rotateSpeed = 2;


    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position; //相机的位置-主角的位置
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = offsetPosition + player.position; //相机的位置 = 位置偏移+主角位置
        //处理视野的左右上下旋转
        RotateView();
        //处理视野的拉近拉远效果
        ScrollView();

    }

    void ScrollView()
    {
        //
        distance = offsetPosition.magnitude; //返回向量的长度
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed; //滚动滚轮，拉近和拉远视野
        distance = Mathf.Clamp(distance, 2, 18); //固定最小值和最大值
        offsetPosition = offsetPosition.normalized * distance; //位置偏移最小为一 
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
        offsetPosition = transform.position - player.position;
    }
}
