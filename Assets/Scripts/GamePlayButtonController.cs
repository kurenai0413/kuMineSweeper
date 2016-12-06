using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayButtonController : MonoBehaviour {

	public void backtoMainMenu()
    {
        Application.LoadLevel("MineSweeper");
    }
}
