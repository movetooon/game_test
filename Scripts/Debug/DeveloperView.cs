using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperView : MonoBehaviour
{
    [SerializeField] private Text n;
    [SerializeField] private Text pointer;
    [SerializeField] private Image[] selectItems;
    [SerializeField] private DeveloperMode mode;

    public void Update()
    {
        n.text = "n: " + mode.GetN().ToString();
        pointer.text = "€чейка: " + mode.GetPointer().ToString();
    }

    public void SelectItem(int i)
    {
        mode.SetItemId(i); 
        for(int j = 0; j < selectItems.Length; j++)
        {
            if (j != i) selectItems[j].color = new Color(1, 1, 1, 0.3f);
            else selectItems[j].color = new Color(1, 1, 1, 1f);
        }
    }
}
