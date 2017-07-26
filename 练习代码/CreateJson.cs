using UnityEngine;
using System.Collections;
using LitJson;

public class CreateJson : MonoBehaviour {

    public string a = "{'Name':'高飞翔','Age':38,'Specialty':'埋汰'}";
    public string b = "{'Name':'地球Online','Type':'VR游戏/第一人称角色扮演','Role':'随机生                           成','Skill':['吃饭','睡觉','排泄','繁殖','工作'],'Monster':['猛犸LV5','剑齿虎                 LV6','树懒LV3','短面熊LV5']}";

    void Start()
    {
        //JsonData data = JsonMapper.ToObject(a);
        //print(data["Name"]);
        //print(data["Age"]);
        //print(data["Specialty"]);    

        //Player p = new Player();
        //p.Name = "高飞翔";
        //p.Age = 35;
        //p.Specialty = "埋汰";
        //string s = JsonMapper.ToJson(p);
        //print(s);

        JsonData j = JsonMapper.ToObject(b);
        IDictionary d = j as IDictionary;
       // print(j["Skill"].ToJson());
        
        foreach (string i in d.Keys)
        {
            print(i);
        }
     /* foreach (var v in d.Values)
        {
            print(v);
        }
      */ 
    }
}

public class Player
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Specialty { get; set; }
}
