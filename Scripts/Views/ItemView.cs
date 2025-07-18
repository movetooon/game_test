 using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text name;
    [SerializeField] private Text description;
    [SerializeField] private Text count;
    [SerializeField] private Text id;

    public void Init(int _id)
    {
        id.text = _id.ToString();
    }

    public void UpdateData(ItemData itemData, int amount)
    {
        icon.enabled = true;
        if (amount == 0)
        {
            BecomeEmpty();
            return;
        }
        icon.sprite = itemData.GetIcon();
        name.text = itemData.GetName();
        description.text = itemData.GetDescription();
        count.text = amount.ToString();
    }

    public void BecomeEmpty()
    {
        icon.sprite = null;
        icon.enabled = false;
        name.text = "";
        description.text = "";
        count.text = "";
    }
}
