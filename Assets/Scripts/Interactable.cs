using UnityEngine;

public class Interactable : MonoBehaviour
{
   public float radius = 3f;

   bool isFocus = false;
   bool hasInteracted = false;
   Transform player;
   public Transform interactionTransform;


   public virtual void Interact()
   {
      // this method is meant ot be overwitten
      Debug.Log("Interacting with " + transform.name);
   }


   public void OnFocused(Transform playerTransform)
   {
      isFocus = true;
      player = playerTransform;
      hasInteracted = false;
   }

   public void OnDefocused()
   {
      isFocus = false;
      player = null;
      hasInteracted = false;
   }

   void OnDrawGizmosSelected()
   {
      if (interactionTransform == null)
         interactionTransform = transform;

      Gizmos.color = Color.yellow;
      Gizmos.DrawWireSphere(interactionTransform.position, radius);
   }


   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (isFocus && !hasInteracted)
      {
         float distance = Vector3.Distance(player.position, interactionTransform.position);
         if (distance <= radius)
         {
            // interaction
            Interact();
            hasInteracted = true;
         }
      }
   }
}
