using UnityEngine;
using System.Collections;


//声明武器抽象类
[System.Serializable] //对这个类进行序列化
public class WeaponData
{
    //武器ID
    public int id;
    //武器预制体
    public Transform prefab;
    //开枪音效
    public AudioClip fireSound;
    //击中音效
    public AudioClip hitSound;
    //击中底面或建筑物时的特效
    public Transform hitLandFX;
    //击中敌人的特效
    public Transform hitEnemyFX;
}
public class WeaponSystem : MonoBehaviour {

    public static WeaponSystem _instance;
    public WeaponData[] weapon;

    //当前武器Id
    private int _curWeaponId = 0; 
    //
    public WeaponData curWeaponDeta;
    public AudioSource audio;  //获取开枪声音
    //开枪间隔
    public float FireWaitTime = 0.2f;
    //下次开抢时间
    public float nexFireTime = 0;

    //设置子弹最大数量
    public int MaxBulletCount = 100;
    //当前用户的子弹数量
    private int _curBulletCount = 100;
    //只读字段
    public int curBulletCount
    {
        get { return _curBulletCount; }
    }

    public int CurWeaponId
    {
        get { return _curWeaponId; }
        set 
        {
            _curWeaponId = value;
            curWeaponDeta = GetWeaponData(_curWeaponId);
        }
    }
	void Start () {

        _instance = this;
	}


    public void Fire()
    {
        
        //间隔设定1，记录开枪时间，计算下次开枪时间,
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nexFireTime)
            {
                nexFireTime = Time.time + FireWaitTime;
                //播放射击音效
                audio.PlayOneShot(curWeaponDeta.fireSound);
                //计算子弹数量
                _curBulletCount -= 1;
                if (_curBulletCount < 0)
                {
                    //子弹用尽时重新赋予子弹数
                    _curBulletCount = MaxBulletCount;
                }

                //进行碰撞检测
                //起始位置
                Vector3 origin = Camera.main.transform.position;
                //方向
                Vector3 direction = Camera.main.transform.forward;
                Ray ray = new Ray(origin, direction);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    //根据击中对象不同标签来区分效果
                    switch (hitInfo.transform.tag)
                    {
                        case "building":
                            Transform bfx = Instantiate(curWeaponDeta.hitLandFX);
                            bfx.position = hitInfo.point;
                            //添加自动销毁脚本
                            bfx.gameObject.AddComponent<AutoDestroy>();
                            break;
                        case "zombie":
                            Transform zfx = Instantiate(curWeaponDeta.hitEnemyFX);
                            zfx.position = hitInfo.point;
                            zfx.gameObject.AddComponent<AutoDestroy>();
                            //设置敌人被击中
                            ZomBie zb = hitInfo.transform.gameObject.GetComponent<ZomBie>();
                            zb.CurActtionType = ZomBie.ActionType.HIT;
                            break;
                    }
                }
            }
           
        }
    }
    #region 获取武器数据
    public WeaponData GetWeaponData(int weaponId)
    {
        foreach(WeaponData wd in weapon){
            if (wd.id == weaponId)
            {
                return wd;
            }
        }
        return null;
    }
    #endregion
    void Update () {

        Fire();
	}
}
