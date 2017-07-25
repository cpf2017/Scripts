using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

   // public GameObject hazard; //障碍物
    public GameObject[] hazards; //一组障碍物
    public Vector3 spawnValues;//障碍物出生点位置数值

    public int hazardCount = 10;// 设置循环生成障碍物的个数
    public float spawnWait = .5f; //设置生成障碍物的世间间隔
    public float waveWait = 4f;  //每一波障碍物的时间间隔
    public float startWait = 1f; //游戏开始的准备时间

    public GUIText scoreTxet; //持有分数的文本的引用
    private int score;         //定义分数

    public GUIText restartText; //重新开始引用
    public GUIText gameOverText; //游戏结束引用

    private bool restart = false;               //何时可以从新开始
    private bool gameOver = false;        //追踪何时游戏结束

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
    void UpdateScore()
    {
        scoreTxet.text = "Score" + score;
    }

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "请输入'R'键重新开始";
                restart = true;
                break;
            }
        }
    }


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();  //调用函数，更新分数
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);  //重新加载当前场景
            }
        }
    }
}
