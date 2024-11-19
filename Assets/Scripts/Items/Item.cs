using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
   new public string name = "New Item";      // name of the item
   public Sprite icon = null;                // item icon
   public bool isDefaultItem = false;        // is the item default wear?

   public virtual void Use()
   {
      // Use the item

      Debug.Log("Using item " +  name);
   }

   public void RemoveFromInventory()
   {
      Inventory.instance.Remove(this);
   }
}
