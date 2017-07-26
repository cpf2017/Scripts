using UnityEngine;
using System.Collections;
using System.Xml;

public class CreateXmlDome : MonoBehaviour {


    public string haoshu;
	// Use this for initialization
	void Start () {

        haoshu = Application.dataPath + "/haoshu.xml";
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 40), "按"))
        {
            Createhaoshu();
        }
    }
	// Update is called once per frame
	void Update () {
	
	}

    void Createhaoshu()
    {
        XmlDocument doc = new XmlDocument();
        XmlElement root = doc.CreateElement("root");
        XmlElement book = doc.CreateElement("book");
        XmlElement title = doc.CreateElement("title");
        XmlElement author = doc.CreateElement("author");
        XmlElement year = doc.CreateElement("year");
        XmlElement price = doc.CreateElement("price");
        book.SetAttribute("category", "悬疑");
        title.InnerText = "红楼梦";
        author.InnerText = "曹雪芹";
        year.InnerText = "1700";
        price.InnerText = "222";
        book.AppendChild(title);
        book.AppendChild(author);
        book.AppendChild(year);
        book.AppendChild(price);
        root.AppendChild(book);
        doc.AppendChild(root);
        doc.Save(haoshu);
    }
}
