using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryMaster : MonoBehaviour
{
    [SerializeField]
    private int xSize;

    [SerializeField]
    private int ySize;

    [Space(10)]
    [SerializeField]
    private GameObject canvasObject;

    //
    //private bool activeInventory;

    // the current item you are holding
    [SerializeField] // debug reasons
    private Item currentItem;

    // mouse properties
    [SerializeField]
    private Transform mouseFollowerPrefab;

    private RectTransform mouseFollower;
    private Image mouseImage;
    private TMP_Text mouseCounter;

    // prefabs
    [SerializeField]
    private GameObject slotPrefab;

    [SerializeField]
    private GameObject slotGarbagePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        // setup grid cellSize
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        float cellSize = grid.padding.left + grid.padding.right + grid.cellSize.x;

        GetComponent<RectTransform>().sizeDelta = new Vector2(cellSize * xSize, cellSize * ySize);

        // setup mouse follower
        mouseFollower = Instantiate(mouseFollowerPrefab, canvasObject.transform).GetComponent<RectTransform>();
        mouseFollower.SetParent(canvasObject.transform);
        mouseImage = mouseFollower.GetComponent<Image>();
        mouseCounter = mouseFollower.GetComponentInChildren<TMP_Text>();

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GameObject slotObject = Instantiate(slotPrefab, this.transform);
                slotObject.GetComponent<InventoryBaseSlot>().Assign(this);
            }
        }

        GameObject slotGarbageObject = Instantiate(slotGarbagePrefab, this.transform);
        slotGarbageObject.GetComponent<InventoryBaseSlot>().Assign(this);
    }

    private void Update()
    {
        // show/hide mousefollow sprite
        if (currentItem != null)
        {
            mouseImage.color = Color.white;
        }
        else
        {
            mouseImage.color = Color.clear;
            mouseCounter.text = "";
        }

        if (currentItem == null)
            return;

        // sprite following mouse when holding a item
        // https://stackoverflow.com/questions/43802207/position-ui-to-mouse-position-make-tooltip-panel-follow-cursor
        Vector3 offset = Vector3.one * 50;
        mouseFollower.anchoredPosition = Input.mousePosition / canvasObject.transform.localScale.x + offset;

        mouseImage.sprite = currentItem.itemSprite;
        mouseCounter.text = currentItem.currentAmount.ToString();
    }

    public Item GetCurrentItem()
    {
        return currentItem;
    }

    public void SetCurrentItem(Item a_Item)
    {
        currentItem = a_Item;
    }
}