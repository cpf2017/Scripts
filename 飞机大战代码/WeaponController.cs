using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public GameObject shot;         //持有敌机子弹预制体的引用
    public Transform shotSpawn;     //子弹发射点
    public float fireRate = 1.5f;   //子弹发射频率
    public float delay = .5f;       //子弹发射延时


    void Start()
    {
        //异步调用函数，反复发射子弹
        InvokeRepeating("fire", delay, fireRate);
    }

    void fire()
    {
        //实例化子弹
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        //播放声音
        this.GetComponent<AudioSource>().Play();
    }
}
