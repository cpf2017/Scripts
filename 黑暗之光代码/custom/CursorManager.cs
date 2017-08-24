using UnityEngine;
using System.Collections;

//控制鼠标指针的类
public class CursorManager : MonoBehaviour {


    public static CursorManager _instance;

    public Texture2D cursor_normal;
    public Texture2D cursor_npc_talk; 
    public Texture2D cursor_attack;
    public Texture2D cursor_lockTarget;
    public Texture2D cursor_pick;



    private Vector2 hotspot = Vector2.zero;
    private CursorMode mode = CursorMode.Auto; //自主选择是硬件设置指针还是软件设置指针


    void Start()
    {
        _instance = this;
    }
    public void SetNormal() //设置为正常的指针
    {  //类
        Cursor.SetCursor(cursor_normal, hotspot, mode); 
    }

    public void SetNpcTalk()  //鼠标点击NPC时的指针状态
    {
        Cursor.SetCursor(cursor_npc_talk, hotspot, mode); 
    }
}
