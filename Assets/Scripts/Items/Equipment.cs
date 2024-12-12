using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
   public EquipmentSlot equipSlot; // slot to store equipment in 
   public SkinnedMeshRenderer meshRenderer;
   public EquipemntMeshRegion[] coveredMeshRegions;

   public int armourModifier; // increase/decrease in armour
   public int damageModifier; // increase/decrease in damage

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

// corresponds to body blendshapes
public enum EquipemntMeshRegion 
{
   Legs, Arms, Torso // corresponds to body blend shapes
} 