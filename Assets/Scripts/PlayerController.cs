using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Direction
{
    NORTH,
    SOUTH,
    EAST,
    WEST
}

public class PlayerController : MonoBehaviour
{
    private TMP_InputField playerInputField;

    // Start is called before the first frame update
    void Start()
    {
        playerInputField = GetComponent<TMP_InputField>();

        playerInputField.onEndEdit.AddListener(OnEndEdit);
        playerInputField.ActivateInputField();
    }

    void QuitGame()
    {
        Debug.Log("Ending Game");
        Application.Quit();
    }

    void OnErrorInput()
    {
        Debug.Log("Invalid Input. Please Try Again.");
    }

    void OnEndEdit(string playerInput)
    {
        playerInputField.text = "";

        playerInput = playerInput.Trim().ToLower();
        switch (playerInput)
        {
            case "":
                OnEmptyInput();
                break;
            case "q":
                QuitGame();
                break;
            case "o":
                ToggleOptions();
                break;
            case "n":
                Move(Direction.NORTH);
                break;
            case "s":
                Move(Direction.SOUTH);
                break;
            case "e":
                Move(Direction.EAST);
                break;
            case "w":
                Move(Direction.WEST);
                break;
            default:
                OnErrorInput();
                break;
        }

        playerInputField.ActivateInputField();
    }

    void OnEmptyInput()
    {
        Debug.Log("Please type a command.");
    }

    private void Move(Direction direction)
    {
        Debug.Log(direction);
        bool success = MainGame.Instance.player.Move(direction);
        if (success)
        {
            MainGame.Instance.gameMap.UpdatePlayerPosition(MainGame.Instance.player.X, MainGame.Instance.player.Y);
        }
        else
        {
            Debug.Log("There's not a room in that direction!");
        }
    }

    void ToggleOptions()
    {
        Debug.Log("Toggling Options");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
