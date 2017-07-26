using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class TestXmlDeSerializer : MonoBehaviour
{
    public GameObject Player;
    PlayerData data;
    string filepath;
    Vector3 TempPos;

    void Start()
    {
        data = new PlayerData();
        filepath = Application.dataPath + "/PlayerData.xml";
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 40, 100, 20), "LosdData"))
        {
            data = DeSerializerData();
            TempPos = new Vector3(data.pos.x, data.pos.y, data.pos.z);
            Player.transform.position = TempPos;
            Player.name = data.Name;
        }
    }

    PlayerData DeSerializerData()
    {
        PlayerData playerdata = new PlayerData();
        FileStream f = new FileStream(filepath, FileMode.Open);
        XmlSerializer xs = new XmlSerializer(typeof(PlayerData));
        playerdata = (PlayerData)xs.Deserialize(f);
        print(playerdata.pos.x + "," + playerdata.pos.y + "," + playerdata.pos.z);
        return playerdata;
    }
}
