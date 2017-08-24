using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public int grade = 1; //等级
    public int hp = 100;  //血量
    public int mp = 100;  //蓝量
    public int coin = 200; //金币数量

    public int attack = 20; //攻击力
    public int attack_plus = 0; //储存加的点数
    public int def = 20;    //防御力
    public int def_plus = 0; //储存加的点数
    public int speed = 20;  //速度
    public int speed_plus = 0;  //储存加的点数


    public int point_remain = 0; //升级后的技能点
    public void GetCoint(int count)
    {
        coin += count;
    }
}
