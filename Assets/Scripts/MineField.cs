using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineField : MonoBehaviour {
    [HideInInspector]               // hide public member in Unity inspector
    public bool isMine;

    private SpriteRenderer sr;

    [SerializeField]                // show private member in Unity inspector
    private Sprite[] images;

    [SerializeField]
    private Sprite mineImage;

	// Use this for initialization
	void Start ()
    {
        isMine = Random.value < 0.15f;
    }

    public void ShowMine()
    {
        if (isMine)
        {
            sr.sprite = mineImage;
        }
    }

    public void ShowNearMinesCount(int nearMines)
    {
        sr.sprite = images[nearMines];
    }

    public bool IsClicked()
    {
        return true;
        //return sr.sprite.texture.name == "Hidden Element"
    }
}
