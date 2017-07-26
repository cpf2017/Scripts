using UnityEngine;
using System.Collections;

public class LianJie : MonoBehaviour {


    void OnClick()
    {
        UILabel L = this.GetComponent<UILabel>();

        string U = L.GetUrlAtPosition(UICamera.lastHit.point);
        if (!string.IsNullOrEmpty(U))
        {
            Application.OpenURL(U);
        }
    }
}
