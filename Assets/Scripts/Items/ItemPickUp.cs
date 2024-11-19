using System;
using UnityEngine;

public class ItemPickUp : Interactable
{
   public Item item;

   public override void Interact()
   {
      base.Interact();
      PickUp();
   }

   void PickUp()
   {
      // pick up item
      bool wasPickedUp =  Inventory.instance.Add(item);

      if(wasPickedUp)
         Destroy(gameObject);

      // add item to inventory
      

   }
}
