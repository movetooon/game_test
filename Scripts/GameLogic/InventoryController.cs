using UnityEngine; 

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Inventory mainInventory;
    [SerializeField] private InventoryView view;  

    public void Start()
    {
        mainInventory.Init();
        view.Init(mainInventory.GetCellMaxCount());
        mainInventory.onUpdateCell += view.UpdateItem;
    } 

    public Inventory GetInventory() => mainInventory;
}

 
