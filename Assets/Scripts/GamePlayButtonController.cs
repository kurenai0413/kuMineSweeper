using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayButtonController : MonoBehaviour {

    public GameObject WinText;

    public static GamePlayButtonController Instance;

    void Awake()
    {
        Instance = this;
    }

    public void RestGame()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.minesCount = 0;
            GameManager.Instance.OnLevelWasLoaded();
        }
        Application.LoadLevel(Application.loadedLevelName); // 上一個load過的levelname
    }
	public void backtoMainMenu()
    {
        Application.LoadLevel("MineSweeper");
    }

    public void ShowWin()
    {
        WinText.SetActive(true);
    }
}
