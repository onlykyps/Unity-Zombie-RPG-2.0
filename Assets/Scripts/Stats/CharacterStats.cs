using UnityEngine;

public class CharacterStats : MonoBehaviour
{

   public int maxHealth = 100;
   public int currentHealth { get; private set; }
   
   public Stat damage;
   public Stat armour;

   private void Awake()
   {
      currentHealth = maxHealth;
   }

   public void TakeDamage(int damage)
   {
      damage -= armour.GetValue();
      damage = Mathf.Clamp(damage, 0, int.MaxValue);

      currentHealth -= damage;
      Debug.Log(transform.name + " takes " + damage + " damage.");

      if(currentHealth <= 0)
      {
         Die();
      }
   }

   public virtual void Die()
   {
      // die in some way
      // this method is ment to be overwritten
      Debug.Log(transform.name + " died");
   }

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if(Input.GetKeyDown(KeyCode.T))
      {
         TakeDamage(10);
      }
   }
}
