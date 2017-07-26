using UnityEngine;
using System.Collections;

public class HongZi : MonoBehaviour {

    public UILabel mLable = null;
    public int mPos = -1;
    public float mTime;
    public string mText = "Every day for 5 minutes, fluent in English language";
	// Use this for initialization
	void Start () {

        mLable = transform.FindChild("Label").GetComponent<UILabel>();
        mLable.text = mText;
	}
	
	// Update is called once per frame
	void Update () {

        mTime += Time.deltaTime;
        if (mTime > 0.5f)
        {
            mPos++;
            mTime = 0;
            if (mPos >= mText.Length)
            {
                mPos = 0;
            }
            string Temp = mText;
            Temp = Temp.Insert(mPos + 1, "[-]");
            Temp = Temp.Insert(mPos, "[ff0000]");
            mLable.text = Temp;
        }
	}
}
