using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isMuted = false;
    public static float audioClipTime = 0;

    [DllImport("__Internal")]
    private static extern bool IsMobile();
    [SerializeField] private GameObject mobileControls;
    public bool _isMobile = false;

    public CoronaMetersManager cm;
    public float score = 0;
    public Text scoreText;
    public static int finalScore = 0;

    public AudioSource bgMusic;
    public GameObject audioOnBtn;
    public GameObject audioOffBtn;
    //public GameObject fullscreenBtn;
    //public GameObject fullscreenOffBtn;

    void Start()
    {
        _isMobile = CheckIfMobile();
        mobileControls.SetActive(_isMobile);
        score = 0;
        scoreText.text = "Score: 0";

        bgMusic.mute = GameManager.isMuted;
        bgMusic.time = GameManager.audioClipTime;
        audioOnBtn.SetActive(!GameManager.isMuted);
        audioOffBtn.SetActive(GameManager.isMuted);
        bgMusic.Play();
    }

    void Update()
    {
        if (cm.globalCoronaMeter > cm.globalCoronaMeterMax || cm.selfCoronaMeter > cm.selfCoronaMaterMax)
        {
            GameOver();
        }

        UpdateScore(Time.deltaTime);

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

    public void UpdateScore(float value)
    {
        score += value;
        scoreText.text = "Score: " + (int) score;
    }

    public void GameOver ()
    {
        finalScore = (int)score;
        GameManager.audioClipTime = bgMusic.time;
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void toggleMute ()
    {
        bgMusic.mute = !bgMusic.mute;
        GameManager.isMuted = bgMusic.mute;
        audioOnBtn.SetActive(!audioOnBtn.activeSelf);
        audioOffBtn.SetActive(!audioOffBtn.activeSelf);
    }

    //public void toggleFullscreen()
    //{
    //    Screen.fullScreen = !Screen.fullScreen;
    //}
}
