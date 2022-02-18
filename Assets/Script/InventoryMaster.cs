using UnityEngine;
using UnityEngine.UI;

public class InventoryMaster : MonoBehaviour
{
    [SerializeField]
    private int xSize;

    [SerializeField]
    private int ySize;

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
    private Vector2 pos;

    [SerializeField]
    private GameObject slotPrefab;

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

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GameObject slotObject = Instantiate(slotPrefab, this.transform);
                slotObject.GetComponent<InventorySlot>().Assign(this);
            }
        }
    }

    private void Update()
    {
        // TODO Show current item holding

        // show/hide mousefollow sprite
        mouseImage.color = currentItem == null ? Color.clear : Color.white;

        if (currentItem == null)
            return;

        // sprite following mouse when holding a item

        // https://stackoverflow.com/questions/43802207/position-ui-to-mouse-position-make-tooltip-panel-follow-cursor
        mouseFollower.anchoredPosition = Input.mousePosition / canvasObject.transform.localScale.x;
    }

    public Item GetCurrentItem()
    {
        return currentItem;
    }
}