using UnityEngine;

public class PlayerStats : CharacterStats
{
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      EquipmentManager.instance.onEquipemntChanged += OnEquipmentChanged;
   }

   // Update is called once per frame
   void Update()
   {

   }

   void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
   {
      if (newItem != null)
      {
         armour.AddModifier(newItem.armourModifier);
         damage.AddModifier(newItem.damageModifier);
      }

      if (oldItem != null)
      {
         armour.RemoveModifier(newItem.armourModifier);
         damage.RemoveModifier(newItem.damageModifier);
      }
   }
}
