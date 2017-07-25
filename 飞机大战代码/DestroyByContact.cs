using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion; //持有爆炸效果的引用
    public GameObject playerExplosion; //持有玩家飞船爆炸效果的引用
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerobject = GameObject.FindWithTag("GameController");
        if (gameControllerobject != null)
        {
            gameController = gameControllerobject.GetComponent<GameController>();
        }
        if (gameControllerobject == null)
        {
            Debug.Log("没有发现‘GameController’脚本");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy") return;

        if (explosion != null)
        {
            Instantiate(explosion, this.transform.position, transform.rotation);
        }
        // Instantiate(explosion, this.transform.position, transform.rotation);
       

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);

        Destroy(other.gameObject);//销毁陨石碰撞到的游戏对象
        Destroy(this.gameObject);//销毁自身
    }
}
