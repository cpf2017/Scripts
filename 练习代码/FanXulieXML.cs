using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
 

public class FanXulieXML : MonoBehaviour {

    public GameObject Player;
    PlayerData data;
    string filepath;
    void Start()
    {
        data = new PlayerData();
        filepath = Application.dataPath + "/PlayerData.xml";
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 20), "SaveData"))
        {
            data.pos.x = Player.transform.position.x;
            data.pos.y = Player.transform.position.y;
            data.pos.z = Player.transform.position.z;
            data.Name = Player.name;
            XmlSerializerData(data);
        }
    }

    void XmlSerializerData(PlayerData data)
    {
        StreamWriter sr;
        FileInfo info = new FileInfo(filepath);
        if (!info.Exists)
        {
            sr = info.CreateText();
        }
        else
        {
            info.Delete();
            sr = info.CreateText();
        }

        XmlSerializer xs = new XmlSerializer(typeof(PlayerData));
        xs.Serialize(sr, data);
        sr.Close();
    }

}

