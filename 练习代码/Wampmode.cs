using UnityEngine;
using System.Collections;

public class Wampmode : MonoBehaviour {

    public string url = "http://192.168.2.101/Unity/modle";

    void Start()
    {
        StartCoroutine(LoadAssetBundler(url));
    }
    IEnumerator LoadAssetBundler(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.isDone)
        {
            GameObject clone = www.assetBundle.LoadAsset("16.2.26.Cube.prefab") as GameObject;
            GameObject clone1 = www.assetBundle.LoadAsset("Sphere.prefab") as GameObject;
            GameObject.Instantiate(clone);
           GameObject.Instantiate(clone1);
        }


        www.Dispose();
    }
}
