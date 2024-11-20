using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
   public EquipmentSlot equipSlot; // slot to store equipment
   public SkinnedMeshRenderer mesh;

   public int armourModifier; // increase/decrease in armor
   public int damageModifier; // increase/decrease in damage

   // when pressed in inventory
   public override void Use()
   {
      base.Use();
      // equip the item
      EquipmentManager.instance.Equip(this);
      // remove from inventory
      RemoveFromInventory();

   }
}

public enum EquipmentSlot
{
   Head, Chest, Legs, Weapon, Shield, Feet
}