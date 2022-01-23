using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int previousX = 1;
    public int X => currentX;
    private int currentX  = 1;

    private int previousY = 4;
    public int Y => currentY;
    private int currentY  = 4;

    public bool Move(Direction direction)
    {
        Debug.Log(MainGame.Instance);
        Debug.Log(MainGame.Instance.gameMap);
        if (direction is Direction.NORTH && MainGame.Instance.gameMap.CheckIfRoomExists(X, Y - 1))
        {
            previousY = currentY;
            currentY--;
            return true;
        }
        else if (direction is Direction.SOUTH && MainGame.Instance.gameMap.CheckIfRoomExists(X, Y + 1))
        {
            previousY = currentY;
            currentY++;
            return true;
        }
        else if (direction is Direction.EAST && MainGame.Instance.gameMap.CheckIfRoomExists(X + 1, Y))
        {
            previousX = currentX;
            currentX++;
            return true;
        }
        else if (direction is Direction.WEST && MainGame.Instance.gameMap.CheckIfRoomExists(X - 1, Y))
        {
            previousX = currentX;
            currentX--;
            return true;
        }
        else return false;
    }

}
