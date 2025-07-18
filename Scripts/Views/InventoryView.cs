using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private ItemView itemViewPrefab;
    [SerializeField] private Transform itemViewParrent;
    private ItemView[] itemViews; 

    public void Init(int slotsCount)
    {
        itemViews = new ItemView[slotsCount];
        for (int i = 0; i < slotsCount; i++) 
        {
            ItemView newItemView = Instantiate(itemViewPrefab, itemViewParrent);
            newItemView.Init(i+1);
            itemViews[i] = newItemView;
        }
    }

    public void UpdateItem(InventoryCell cell )
    { 
        itemViews[cell.GetId()].UpdateData(cell.GetItemData(),cell.GetCount()); 
    }
     
}
