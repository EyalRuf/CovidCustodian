using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();
    [SerializeField] private GameObject mobileControls;
    public bool _isMobile = false;

    public CoronaMetersManager cm;
    public AudioSource bgMusic;
    public GameObject audioOnBtn;
    public GameObject audioOffBtn;
    //public GameObject fullscreenBtn;
    //public GameObject fullscreenOffBtn;

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

        //fullscreenBtn.SetActive(!Screen.fullScreen);
        //fullscreenOffBtn.SetActive(Screen.fullScreen);
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

    public void toggleMute ()
    {
        bgMusic.mute = !bgMusic.mute;
        audioOnBtn.SetActive(!audioOnBtn.activeSelf);
        audioOffBtn.SetActive(!audioOffBtn.activeSelf);
    }

    //public void toggleFullscreen()
    //{
    //    Screen.fullScreen = !Screen.fullScreen;
    //}
}
