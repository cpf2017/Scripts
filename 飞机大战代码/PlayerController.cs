using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    public float speed = 10f; //飞船速度
    public Boundary boundary;//持有Boundary的引用
    public float tilt = 4f;//飞船横移的倾斜角度
    //public float xMin, xMax, zMin, zMax;
   // public AudioSource a; 


    public GameObject shot; //子弹预设
    public Transform shotSpawn;  //子弹的挂载点

    public float fireRate = .25f; //子弹的开火频率
    public float nextFire = 0f;//发射下一发子弹的时间点

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
         //1- 控制飞船
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        this.GetComponent<Rigidbody>().velocity = movement * speed;
        //2- 控制飞船位置

        this.transform.position = new Vector3
        (
            Mathf.Clamp(this.GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(this.GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
         );
        //控制飞船倾斜效果

        this.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 0f, this.GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space)&&Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
            this.GetComponent<AudioSource>().Play();
        }
    }

}
