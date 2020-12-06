using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    [SerializeField] private GameObject mobileControls;

    // Start is called before the first frame update
    void Start()
    {
        if (isMobile())
        {
            mobileControls.SetActive(true);
        }
    }

    public bool isMobile()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
        #endif
        return false;
    }
}
