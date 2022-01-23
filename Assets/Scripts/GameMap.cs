using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    [SerializeField]
    private TMP_FontAsset consolasNormal;
    [SerializeField]
    private TMP_FontAsset consolasBold;
    [SerializeField]
    private float gameMapScale = 1.25f;

    [SerializeField]
    private GameObject roomPrefab;
    private RectTransform gameMapRectTransform;
    private TextMeshProUGUI[,] gameMap = new TextMeshProUGUI[5, 5];

    private TextMeshProUGUI currentPlayerPosition;

    private void Awake()
    {
        gameMapRectTransform = GetComponent<RectTransform>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void BuildMap()
    {
        // Because this is ported from a python nested array,
        // Accessing this 2D array should use
        // [y, x] instead of [x, y].
        int[,] gameMapTemplate = new int[5, 5] {
            { 2, 0, 0, 1, 1 },
            { 1, 1, 4, 1, 3 },
            { 1, 0, 1, 0, 1 },
            { 1, 5, 0, 0, 1 },
            { 1, 7, 0, 6, 1 }
        };

        RectTransform roomPrefabRectTransform = roomPrefab.GetComponent<RectTransform>();
        gameMapRectTransform.sizeDelta = new Vector2(roomPrefabRectTransform.sizeDelta.x * 5, roomPrefabRectTransform.sizeDelta.y * 5);

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (gameMapTemplate[y, x] == 0) continue;

                Vector3 roomPosition = new Vector3(
                    transform.position.x + (x * roomPrefabRectTransform.sizeDelta.x),//) * gameMapScale,
                    transform.position.y - (y * roomPrefabRectTransform.sizeDelta.y),//) * gameMapScale,
                    0
                );
                gameMap[x, y] = Instantiate(roomPrefab, roomPosition, Quaternion.identity, transform).GetComponent<TextMeshProUGUI>();
            }
        }
        gameMapRectTransform.localScale = new Vector3(gameMapScale, gameMapScale, gameMapScale);

        foreach (TextMeshProUGUI t in gameMap)
        {
            if (t != null)
            {
                Debug.Log(t.text);
            }
        }
    }

    public bool CheckIfRoomExists(int x, int y)
    {
        return (
            x >= 0 && x < gameMap.GetLength(0) &&
            y >= 0 && y < gameMap.GetLength(1) &&
            gameMap[x, y] != null
        );
    }

    public void UpdatePlayerPosition(int x, int y)
    {
        if (currentPlayerPosition != null)
        {
            currentPlayerPosition.font = consolasNormal;
            currentPlayerPosition.color = Color.white;
        }

        currentPlayerPosition = gameMap[x, y];

        currentPlayerPosition.font = consolasBold;
        currentPlayerPosition.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
