using System;
using UnityEngine; 

[System.Serializable]
public class Inventory
{
    [SerializeField] private int cellMaxCount;
    private InventoryCell[] cells;
    public Action<InventoryCell> onUpdateCell;

    public void Init()
    {
        cells = new InventoryCell[cellMaxCount];
        for(int i = 0; i < cells.Length; i++)
        {
            cells[i] = new InventoryCell(i);
        }
    }

    public bool TryAdd(ItemData item, int cellId =-1, int count = 1)
    {
        if (count <= 0) count = 0;

        while (count != 0)
        {
            int nextCellId = GetFirstUnBusyCell(item, cellId);
            
            if (nextCellId == -1)
            {
                Debug.Log("inventory is full");
                break;
            }
            int amountToAdd = Math.Min(
                cells[nextCellId].GetMaxCount() - cells[nextCellId].GetCount(),
                count);
            Add(item, amountToAdd, nextCellId);
            count -= amountToAdd;
        }

        return true;
         
    }

    private void Add(ItemData item, int count = 1, int cellId=0)
    { 
        cells[cellId].Add(item, count);
        onUpdateCell?.Invoke(cells[cellId]);
    } 
     
     
    public void Remove(int cellId, int count = 1)
    {
        if (count < 0) count = 0;
        if (cells?[cellId] == null)
        {
            Debug.Log("empty cell");
            return;
        }

        cells[cellId].Remove(count);
        onUpdateCell?.Invoke(cells[cellId]);
    }

    public int GetFirstUnBusyCell(ItemData item, int start=0)
    { 
        if (start < 0) start = 0;
        for (int i = start; i < cellMaxCount; i++)
        { 
            if (cells[i].GetItemData() == item
                && cells[i].GetCount() < cells[i].GetMaxCount()) 
                return i;
          
            if (cells[i].isBusy() == false) return i;
        }
        return -1;
    } 

    public int GetCellMaxCount() => cellMaxCount;
     
}