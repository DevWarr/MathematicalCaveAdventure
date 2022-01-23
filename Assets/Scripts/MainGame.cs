using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private MainGame() { }
    public static MainGame Instance;

    public GameMap gameMap;
    public PlayerController playerController;
    // Because the Player doesn't exist in the Unity scene, we actually create one
    public Player player = new Player();


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        gameMap.BuildMap();
        gameMap.UpdatePlayerPosition(player.X, player.Y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
