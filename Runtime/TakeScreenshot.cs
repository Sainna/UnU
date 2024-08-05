using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{

    [SerializeField]
    KeyCode _ScreenShotKey = KeyCode.S;

    [SerializeField]
    int _Supersize = 2;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(_ScreenShotKey))
        {
            string datetime = System.DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss");
            // ScreenCapture.CaptureScreenshot(System.DateTime.Now.ToString("s") + ".png", _Supersize);
            ScreenCapture.CaptureScreenshot("Echoes_" + datetime + ".png", _Supersize);
        }
        
    }
}
