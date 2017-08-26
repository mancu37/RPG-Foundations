using System;
using UnityEngine;

public class ItemPickUp : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUpItem();
    }

    private void PickUpItem()
    {
        Debug.LogFormat("Agarrando objeto {0}", item.name);

        //Agregarlo al inventario
        Inventory.instance.AddItem(item);

        Destroy(gameObject);
    }
}
