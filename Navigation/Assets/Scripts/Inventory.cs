using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;



    public List<Item> items = new List<Item>();

    void Awake()
    {
        instance = this;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
