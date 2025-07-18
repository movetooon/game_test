using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    [SerializeField, Min(0)] private int pointerInInventory; 
    [SerializeField, Min(0)] private int itemId; 
    [SerializeField, Min(0)] private int n;
    [SerializeField] private ItemData[] items;
    [SerializeField] private InventoryController inventoryController;
    private Inventory testInventory;


    private void Start()
    {
        testInventory = inventoryController.GetInventory();
    }

    public void Update()
    {
        CheckAllCorrect(); 

        if (Input.GetKeyDown(KeyCode.W)
            && pointerInInventory> 0) pointerInInventory--;
        if (Input.GetKeyDown(KeyCode.S)
           && pointerInInventory < testInventory.GetCellMaxCount()) pointerInInventory++;
        
        if (Input.GetKeyDown(KeyCode.Space))
            testInventory.TryAdd(items[itemId], pointerInInventory, n);
        if (Input.GetKeyDown(KeyCode.Q))
            testInventory.Remove(pointerInInventory,n);
       
        if (Input.GetKeyDown(KeyCode.Equals)) n++;
        if (Input.GetKeyDown(KeyCode.Minus)&&n>0) n--;

    }

    public void CheckAllCorrect()
    {
        if (pointerInInventory >= inventoryController.GetInventory().GetCellMaxCount()) pointerInInventory = items.Length;
        if (itemId >= items.Length) itemId = items.Length - 1;
    }
    public void SetItemId(int id)=>itemId = id;
    public int GetN() => n;
    public int GetPointer() => pointerInInventory;
}
