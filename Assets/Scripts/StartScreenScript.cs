using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    public int currScreen = 0;
    public GameObject[] screens;
    public AudioSource bgMusic;
    public GameObject audioOnBtn;
    public GameObject audioOffBtn;

    void Start()
    {
        bgMusic.mute = GameManager.isMuted;
        bgMusic.time = GameManager.audioClipTime;
        audioOnBtn.SetActive(!GameManager.isMuted);
        audioOffBtn.SetActive(GameManager.isMuted);
        bgMusic.Play();
    }

    public void NextScreen ()
    {
        if (currScreen < screens.Length - 1) {
            screens[currScreen].SetActive(false);
            screens[++currScreen].SetActive(true);
        } else {
            GameManager.audioClipTime = bgMusic.time;
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    public void ToggleMute()
    {
        bgMusic.mute = !bgMusic.mute;
        GameManager.isMuted = bgMusic.mute;
        audioOnBtn.SetActive(!audioOnBtn.activeSelf);
        audioOffBtn.SetActive(!audioOffBtn.activeSelf);
    }
}
