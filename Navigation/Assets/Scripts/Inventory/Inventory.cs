using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {




    public static Inventory instance;
    

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    void Awake()
    {
        instance = this;

    }

    public void AddItem(Item item)
    {
        items.Add(item);
        onItemChangedCallback.Invoke();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        onItemChangedCallback.Invoke();
    }
}
