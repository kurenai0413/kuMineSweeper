using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGrid {
    public static MineField[,] mineFields;

	public static void ShowAllMines()
    {
        foreach(MineField mf in mineFields)
        {
            mf.ShowMine();
        }
    }

    public static bool MineAtCoordinates(int x, int y)
    {
        if (x>=0 && y>=0 && x<GameManager.Instance.rows && y < GameManager.Instance.columns)
        {
            if (mineFields[x, y].isMine)
                return true;
        }
        return false;
    }

    public static int NearMines(int x, int y)
    {
        int count = 0;

        if (MineAtCoordinates(x, y + 1))            // Up
            count++;
        if (MineAtCoordinates(x + 1, y + 1))        // Upper-Right
            count++;
        if (MineAtCoordinates(x - 1, y + 1))        // Upper-Left
            count++;
        if (MineAtCoordinates(x - 1, y))            // Left
            count++;
        if (MineAtCoordinates(x + 1, y))            // Right
            count++;
        if (MineAtCoordinates(x - 1, y - 1))        // Bottom-Left
            count++;
        if (MineAtCoordinates(x, y - 1))            // Bottom
            count++;
        if (MineAtCoordinates(x + 1, y - 1))        // Bottom-Right
            count++;

        return count;
    }

    public static void InvestigateMines(int x, int y, bool [,] visited)
    {
        if (x>=0 && y>=0 && x<GameManager.Instance.rows && y <GameManager.Instance.columns)
        {
            if (visited[x, y])
                return;

            mineFields[x, y].ShowMine();
            mineFields[x, y].ShowNearMinesCount(NearMines(x,y));

            if (NearMines(x, y) > 0)
                return;

            visited[x, y] = true;

            InvestigateMines(x - 1, y, visited);
            InvestigateMines(x + 1, y, visited);
            InvestigateMines(x, y + 1, visited);
            InvestigateMines(x, y + 1, visited);
            InvestigateMines(x - 1, y - 1, visited);
            InvestigateMines(x - 1, y + 1, visited);
            InvestigateMines(x + 1, y - 1, visited);
            InvestigateMines(x + 1, y + 1, visited);
        }
    }

    public static bool IsGameIsFinished()
    {
        foreach (MineField mf in mineFields)
        {
            if (mf.IsClicked() && !mf.isMine)
            {
                return false;
            }
        }

        return true;
    }
}
