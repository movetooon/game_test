using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemData : ScriptableObject
{ 
    [SerializeField] private string name;
    [SerializeField, TextArea(1, 150)] private string description;
    [SerializeField] private Sprite icon;

    public string GetName() => name;
    public string GetDescription() => description;
    public Sprite GetIcon() => icon;
}

 