using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class NetWorkTest : MonoBehaviour {

    private string Ip = "192.168.2.112";
    public Button bnt = null;
    public Button bnt2 = null;
    public Text t;
    public Text text1;
    public Text text2;
    public bool isServer = false;
    public bool isClient = false;
	void Start () {

        bnt = transform.Find("But").GetComponent<Button>();
        bnt2 = transform.Find("Btn").GetComponent<Button>();
        text1 = bnt.transform.Find("Text1").GetComponent<Text>();
        text2 = bnt2.transform.Find("Text2").GetComponent<Text>();
        t = transform.Find("Text").GetComponent<Text>();
        bnt.onClick.AddListener(Server);
        bnt2.onClick.AddListener(ServerDome);
	}



    void Server()
    {
        isClient = !isClient;
        if (isClient)
        {
            NetworkConnectionError error = Network.InitializeServer(10, 10433, false);
            
            if (error == NetworkConnectionError.NoError)
            {
                print("创建服务器成功");
                text1.text = "断开服务器";
            }
        }
        else
        {
            Network.Disconnect();
            text1.text = "创建服务器";

        }
    }

    void ServerDome()
    {
        isServer = !isServer;
        if (isServer)
        {
            NetworkConnectionError error = Network.Connect(Ip, 10086);
            if (error == NetworkConnectionError.NoError)
            {
                print("连接服务器成功");
                text2.text = "断开连接";
            }
        }
        else
        {
            Network.Disconnect();
            text2.text = "连接服务器";
        }
    }
	void Update () {

        t.text = "当前数量：" + Network.connections.Length;
	}
}
