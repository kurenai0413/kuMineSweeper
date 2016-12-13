using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionController : MonoBehaviour {

	public void SelectLevel()
    {
        string level
            = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        switch (level)
        {
            case "Easy":
                //Debug.Log("Easy~");
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.rows    = 8;
                    GameManager.Instance.columns = 9;
                    GameManager.Instance.cameraX = 3.5f;
                    GameManager.Instance.cameraY = 5.5f;
                    GameManager.Instance.level = GameManager.Level.Easy;
                }
                break;
            case "Medium":
                //Debug.Log("Medium~~");
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.rows = 9;
                    GameManager.Instance.columns = 11;
                    GameManager.Instance.cameraX = 4f;
                    GameManager.Instance.cameraY = 7f;
                    GameManager.Instance.level = GameManager.Level.Medium;
                }
                break;
            case "Hard":
                //Debug.Log("Hard~~~");
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.rows = 10;
                    GameManager.Instance.columns = 13;
                    GameManager.Instance.cameraX = 4.5f;
                    GameManager.Instance.cameraY = 7f;
                    GameManager.Instance.level = GameManager.Level.Hard;
                }
                break;
        }
    }

    public void backMainMenu()
    {
        Application.LoadLevel("MineSweeper");
    }
}
