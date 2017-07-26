using UnityEngine;
using System.Collections;


public class PlayerData
{
    public struct _Pos
    {
        public float x, y, z;
    }
    public _Pos pos;


    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

