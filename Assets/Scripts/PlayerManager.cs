using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   #region Singleton
   public static PlayerManager instance;
   void Awake()
   {
      instance = this;
   }
   #endregion

   public GameObject player;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }
}
