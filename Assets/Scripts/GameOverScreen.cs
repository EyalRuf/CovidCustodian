using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void PostToFB(int score);
    [DllImport("__Internal")]
    private static extern void Tweet(int score);


    public Text finalScoreTxt1;
    public Text finalScoreTxt2;

    public AudioSource bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        finalScoreTxt1.text = "" + GameManager.finalScore;
        finalScoreTxt2.text = "" + GameManager.finalScore;

        bgMusic.mute = GameManager.isMuted;
        bgMusic.time = GameManager.audioClipTime;
        bgMusic.Play();
    }

    public void Retry()
    {
        GameManager.audioClipTime = bgMusic.time;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Home()
    {
        GameManager.audioClipTime = bgMusic.time;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Twitt()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            Tweet(GameManager.finalScore);
        #else
            Application.OpenURL("https://twitter.com/intent/tweet?text=My Covid Custodian score is "+ 
                GameManager.finalScore + "! Think you can beat me? Try here: https://eyalruf.itch.io/covid-custodian");
        #endif
    }

    public void FB()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            PostToFB(GameManager.finalScore);
        #else
            Application.OpenURL("http://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Feyalruf.itch.io%2Fcovid-custodian&quote=My%20Covid%20Custodian%20score%20is%20" +
                GameManager.finalScore + "!%20Think%20you%20can%20beat%20me%3F%20try%20here");
        #endif
    }
}
