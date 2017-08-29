using UnityEngine;


[CreateAssetMenu(fileName = "New File", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Name";
    public Sprite icon;


    public virtual void Use()
    {
        Debug.Log("Using the item: " + name);
    }
}
