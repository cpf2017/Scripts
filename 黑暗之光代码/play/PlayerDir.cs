using UnityEngine;
using System.Collections;

public class PlayerDir : MonoBehaviour {

    public GameObject effect_click_prefab;
    public Vector3 targetPosition = Vector3.zero; //目标位置。
    private bool isMoving = false; //表示鼠标是否按下
    private PlayerMove playerMove;

    void Start()
    {
        targetPosition = transform.position; //目标位置默认为当前位置
        playerMove = this.GetComponent<PlayerMove>();
    }
	void Update () {
                                             //当前鼠标下是否有NUI控件，为空就是没有控件
        if (Input.GetMouseButtonDown(0) && UICamera.hoveredObject.name == "UI Root") //点击鼠标的左键
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //发射一个射线
            RaycastHit hitInfo; //碰到的物体
            bool isCollider = Physics.Raycast(ray, out hitInfo); //检测是否碰撞到物体
            if (isCollider && hitInfo.collider.tag == Tags.ground) //碰到了东西并且碰到了底面
            {
                isMoving = true;
                ShowClickEffect(hitInfo.point); //将碰撞位置传入方法
                LookAtTarget(hitInfo.point);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            //得到要移动的目标位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //发射一个射线
            RaycastHit hitInfo; //碰到的物体
            bool isCollider = Physics.Raycast(ray, out hitInfo); //检测是否碰撞到物体
            if (isCollider && hitInfo.collider.tag == Tags.ground) //碰到了东西并且碰到了底面
            {
                //让主角朝向目标位置
                LookAtTarget(hitInfo.point);
            }
        }
        else
        {
            if (playerMove.isMoving)
            {
                LookAtTarget(targetPosition);
            }
        }
	}
    //实例化出来点击的效果
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.3f, hitPoint.z);
        GameObject.Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }
    //让主角朝向目标位置
    void LookAtTarget(Vector3 hitPoint)
    {
        targetPosition = hitPoint; //目标位置就是底面点击位置
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z); //让目标位置和主角位置在Y轴上保持一致
        this.transform.LookAt(targetPosition);
    }
}
