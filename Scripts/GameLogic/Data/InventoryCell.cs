using UnityEngine;


[System.Serializable]
public class InventoryCell
{
    private ItemData item;
    private int count;
    private int maxCount;
    private int id;

    public InventoryCell(int _id, int _maxCount=16)
    {
        count = 0;
        id = _id;
        maxCount = _maxCount;
    }

    public void Add(ItemData _item, int amount = 1)
    {
        if (amount < 0)
        {
            Debug.Log("count error");
            return;
        }

        if (count != 0)
        {
            count += amount;
            return;
        }
        item = _item;
        count += amount;
    }


    public void Remove(int amount)
    {
        if (amount < 0)
        {
            Debug.Log("count error");
            return;
        }

        if (count - amount >= 1) count -= amount;
        else if (count - amount == 0)
        {
            count = 0;
            item = null;
        }
        else
        {
            Debug.Log("too much items to remove");
            return;
        }
    }
    public bool isBusy() => count != 0;
    public int GetCount() => count;
    public int GetMaxCount() => maxCount;
    public int GetId() => id;
    public ItemData GetItemData() => item;
}

