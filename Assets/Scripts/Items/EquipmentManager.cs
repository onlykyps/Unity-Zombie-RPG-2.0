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
   SkinnedMeshRenderer[] currentMeshes; // items we currently have equipped
   public SkinnedMeshRenderer targetMesh;

   Inventory inventory; // reference to our inventory

   // callback for when an item is equipped or unequipped 
   public delegate void OnEquipemntChanged(Equipment newItem, Equipment oldItem);
   public OnEquipemntChanged onEquipemntChanged;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      inventory = Inventory.instance;

      // initialize currentEquipment based on number of equipment slots
      int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
      currentEquipment = new Equipment[numSlots];

      currentMeshes = new SkinnedMeshRenderer[numSlots];
   }

   // equip a new item
   public void Equip(Equipment newItem)
   {
      // find out what slot the item fits in
      int slotIndex = (int)newItem.equipSlot;
      Equipment oldItem = null;

      // if there was already an item in the slot
      // make sure to puut it back in the inventory
      if (currentEquipment[slotIndex] != null)
      {
         oldItem = currentEquipment[slotIndex];
         inventory.Add(oldItem);
      }

      // insert item in the next slot
      if (onEquipemntChanged != null)
      {
         onEquipemntChanged.Invoke(newItem, oldItem);
      }

      currentEquipment[slotIndex] = newItem;
      SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.meshRenderer);
      newMesh.transform.parent = newMesh.transform;

      newMesh.bones = targetMesh.bones;
      newMesh.rootBone = targetMesh.rootBone;

      currentMeshes[slotIndex] = newMesh;
   }

   // unequip an item with particular index
   public void Unequip(int slotIndex)
   {
      if (currentEquipment[slotIndex] != null)
      {
         if (currentMeshes[slotIndex] == null)
         {
            Destroy(currentMeshes[slotIndex].gameObject);
         }
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
      if (Input.GetKeyDown(KeyCode.U))
      {
         UnequipAll();
      }
   }

   void SetEquipmentBlendShapes(Equipment item, int weight)
   {
      foreach (EquipemntMeshRegion blendShape in item.coveredMeshRegions)
      {
         targetMesh.SetBlendShapeWeight((int)blendShape, weight);
      }
   }
}
