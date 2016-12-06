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
                Debug.Log("Easy~");
                break;
            case "Medium":
                Debug.Log("Medium~~");
                break;
            case "Hard":
                Debug.Log("Hard~~~");
                break;
        }
    }

    public void backMainMenu()
    {
        Application.LoadLevel("MineSweeper");
    }
}
