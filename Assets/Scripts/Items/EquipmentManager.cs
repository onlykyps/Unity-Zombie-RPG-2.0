using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
   #region Singleton
   public static EquipmentManager instance;
   private void Awake()
   {
      instance = this;
   }
   #endregion

   Equipment[] currentEquipment;
   Inventory inventory;
   public delegate void OnEquipemntChanged(Equipment newItem, Equipment oldItem);
   public OnEquipemntChanged onEquipemntChanged;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      inventory = Inventory.instance;

      int numSlots =  System.Enum.GetNames(typeof(EquipmentSlot)).Length;
      currentEquipment = new Equipment[numSlots];
   }

   public void Equip(Equipment newItem)
   {
      int slotIndex = (int)newItem.equipSlot;
      Equipment oldItem = null;


      if(currentEquipment[slotIndex] != null)
      {
         oldItem = currentEquipment[slotIndex];
         inventory.Add(oldItem);
      }

      if(onEquipemntChanged != null)
      {
         onEquipemntChanged.Invoke(newItem, oldItem);
      }

      currentEquipment[slotIndex] = newItem;
   }

   public void Unequip(int slotIndex)
   {
      if(currentEquipment[slotIndex]!=null)
      {
         Equipment oldItem = currentEquipment[slotIndex];
         inventory.Add(oldItem);

         currentEquipment[slotIndex] = null;

         if (onEquipemntChanged != null)
         {
            onEquipemntChanged.Invoke(null, oldItem);
         }

      }
   }

   public void UnequipAll()
   {
      for (int i = 0; i < currentEquipment.Length; i++)
      {
         Unequip(i);
      }
   }

   // Update is called once per frame
   void Update()
   {
      if(Input.GetKeyDown(KeyCode.U))
      {
         UnequipAll();
      }
   }
}
