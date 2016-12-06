﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public void PlayGame()
    {
        Application.LoadLevel("GamePlay");
    }

    public void GotoOption()
    {
        Application.LoadLevel("OptionMenu");
    }
}
