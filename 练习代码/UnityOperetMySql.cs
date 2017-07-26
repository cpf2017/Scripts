using UnityEngine;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;

public class UnityOperetMySql : MonoBehaviour {


    public string ServerIP = "localhost";
    public string dataName = "unity3d_1703";
    public string UserID = "root";
    public string Password = "1043374540";

    MySqlConnection mySqlconnetion;
    string connetionStr = "";
    string cmdText = "Select*From sql作业";
    //string cmdText1 = "Insert into sql作业 values(1004,'wangermazi',1478,'男',32,'wangermazi@163.coml')";

    string cmdText1 = "delete from sql作业 Where ID= 1001;";
    void Start()
    {
        connetionStr = string.Format("Server={0};Database={1};User ID ={2};Password={3}", ServerIP, dataName, UserID, Password);

        mySqlconnetion = new MySqlConnection(connetionStr);

        if (mySqlconnetion != null)
        {
            mySqlconnetion.Open();
        }

        MySqlCommand command = new MySqlCommand(cmdText1, mySqlconnetion);
        int hasRows = command.ExecuteNonQuery();
        print(hasRows);
        MySqlCommand command1 = new MySqlCommand(cmdText, mySqlconnetion);

        MySqlDataReader reader = command1.ExecuteReader();
        if (reader.HasRows)  //判断是否还有行数
        {
            while (reader.Read()) //是否正在读取内容
            {
                string dataStr = "";
                dataStr += reader["用户名"] + ",,";
                print(dataStr);
            }
        }

    }
}
