using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayButtonController : MonoBehaviour {

    public void RestGame()
    {
        Application.LoadLevel(Application.loadedLevelName); // 上一個load過的levelname
    }
	public void backtoMainMenu()
    {
        Application.LoadLevel("MineSweeper");
    }
}
