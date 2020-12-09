using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();
    [SerializeField] private GameObject mobileControls;
    public bool _isMobile = false;

    public CoronaMetersManager cm;

    // Start is called before the first frame update
    void Start()
    {
        _isMobile = CheckIfMobile();
        mobileControls.SetActive(_isMobile);
    }

    void Update()
    {
        if (cm.globalCoronaMeter > cm.globalCoronaMeterMax || cm.selfCoronaMeter > cm.selfCoronaMaterMax)
        {
            GameOver();
        }
    }

    public bool CheckIfMobile()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
        #endif
        return false;
    }

    public void GameOver ()
    {
        Time.timeScale = 0;

        // calc total score

        // transition to game over scene
    }
}
