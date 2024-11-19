using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   #region Singleton

   public static Inventory instance;
   void Awake()
   {
      if (instance != null)
      {
         Debug.Log("more than one instance of inventory found");
         return;
      }
      else
      {
         instance = this;
      }
   }

   #endregion

   public List<Item> items = new List<Item>();
   public int space ;

   public delegate void OnItemChanged();
   public OnItemChanged onItemChangedCallback;

   public bool Add(Item item)
   {
      if (!item.isDefaultItem)
         if (items.Count >= this.space)
         {
            Debug.Log("we do not have enough room");
            return false;
         }
         else
         {
            items.Add(item);
            if(onItemChangedCallback != null)
               onItemChangedCallback.Invoke();
         }

      return true;
   }

   public void Remove(Item item)
   {
      items.Remove(item);
      if (onItemChangedCallback != null)
         onItemChangedCallback.Invoke();
   }

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }
}
