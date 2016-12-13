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

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start ()
    {
        isMine = Random.value < 0.15f;
        if (isMine)
        {
            if (GameManager.Instance.CanBeMine())
                GameManager.Instance.IncrementMineInGame();
            else
                isMine = false;
        }
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
        return sr.sprite.texture.name == "Hidden Element";
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Right mouse");
            if (sr.sprite != images[9])
            {
                sr.sprite = images[9];
                if (MatrixGrid.IsGameIsFinished())
                {
                    print("You Win!");
                    GamePlayButtonController.Instance.ShowWin();
                }
            }
            else if (sr.sprite == images[9])
            {
                sr.sprite = images[10];
            }
        }
    }

    void OnMouseDown()
    {
        if(sr.sprite != images[9])
        {
            if (isMine)
            {
                MatrixGrid.ShowAllMines();
                print("Game Over!!");
            }
            else
            {
                string[] index = gameObject.name.Split('-');
                int x = int.Parse(index[0]);
                int y = int.Parse(index[1]);
                ShowNearMinesCount(MatrixGrid.NearMines(x, y));
                MatrixGrid.InvestigateMines(x, y, new bool[GameManager.Instance.rows, GameManager.Instance.columns]);
                if (MatrixGrid.IsGameIsFinished())
                {
                    print("You Win!");
                    GamePlayButtonController.Instance.ShowWin();
                }
            }
        }
    }
}
