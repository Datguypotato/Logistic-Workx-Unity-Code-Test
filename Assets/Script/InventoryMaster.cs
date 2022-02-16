using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryMaster : MonoBehaviour
{
    [SerializeField]
    private int xSize;

    [SerializeField]
    private int ySize;

    [SerializeField]
    private GameObject slotPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        float cellSize = grid.padding.left + grid.padding.right + grid.cellSize.x;

        GetComponent<RectTransform>().sizeDelta = new Vector2(cellSize * xSize, cellSize * ySize);

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Instantiate(slotPrefab, this.transform);
            }
        }
    }
}