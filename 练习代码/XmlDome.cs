using UnityEngine;
using System.Collections;
using System.Xml;

public class XmlDome : MonoBehaviour {

    XmlDocument doc = new XmlDocument(); 
	// Use this for initialization
	void Start () {

        doc.Load(Application.dataPath + "/HH.xml");
        XmlElement root = doc.DocumentElement;
        print(root.Name);

        XmlNode hh = root.SelectSingleNode("book");
        print(hh.Name);
        XmlNodeList list = hh.ChildNodes;

        for (int i = 0; i < list.Count; i++)
        {

            if (list[i].Name == "title")
            {
                list[i].InnerText = "BABAB";
                print(list[i].InnerText);

                XmlElement x = (XmlElement)list[i];
                x.SetAttribute("lang","en");
                doc.Save(Application.dataPath + "/HH.xml");

            }
            if (list[i].Name == "author")
            {
                print(list[i].InnerText);
            }
     
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
