using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField]
    GameObject mineField;

    [HideInInspector]
    public int rows;
    [HideInInspector]
    public int columns;
    [HideInInspector]
    public float cameraX, cameraY;
    
    public enum Level { Easy, Medium, Hard};
    [HideInInspector]
    public Level level;

    private int easyLevelMinesCount = 14;
    private int mediumLevelMinesCount = 20;
    private int hardLevelMinesCount = 30;

    [HideInInspector]
    public int minesCount;

    private void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        rows    = 9;
        columns = 11;

        cameraX = 4f;
        cameraY = 7f;

        minesCount = 0;
        level = Level.Medium;

        //OnLevelWasLoaded();
    }
	
    public void OnLevelWasLoaded()
    {
        if (Application.loadedLevelName == "GamePlay")
        {
            MatrixGrid.mineFields = new MineField[rows, columns];
            Camera.main.transform.position
                = new Vector3(cameraX, cameraY, Camera.main.transform.position.z);
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    GameObject mine = Instantiate(mineField, new Vector3(x, y, 0),
                                                  Quaternion.identity) as GameObject;
                    mine.name = x + "-" + y;
                    MatrixGrid.mineFields[x, y] = mine.GetComponent<MineField>();
                    MatrixGrid.mineFields[x, y].enabled = true;
                }
            }
        }
        else
        {
            minesCount = 0;       
        }
    }

    public bool CanBeMine()
    {
        switch(level)
        {
            case Level.Easy:
                if (minesCount < easyLevelMinesCount)
                    return true;
                else
                    return false;
                break;

            case Level.Medium:
                if (minesCount < mediumLevelMinesCount)
                    return true;
                else
                    return false;
                break;

            case Level.Hard:
                if (minesCount < hardLevelMinesCount)
                    return true;
                else
                    return false;
                break;
            default:
                return false;
                break;
        }
    }

    public void IncrementMineInGame()
    {
        minesCount++;
    }

}//GameManager
