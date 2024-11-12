using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
   public LayerMask movementMask;
   Camera camera;
   PlayerMotor motor;

   public Interactable focus;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      camera = Camera.main;
      motor = GetComponent<PlayerMotor>();
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Ray ray = camera.ScreenPointToRay(Input.mousePosition);
         RaycastHit raycastHit;

         if (Physics.Raycast(ray, out raycastHit, 100, movementMask))
         {
            // move our player to what we hit
            motor.MoveToPoint(raycastHit.point);

            // stop focusing any objects
            RemoveFocus();
         }
      }

      if (Input.GetMouseButtonDown(1))
      {
         Ray ray = camera.ScreenPointToRay(Input.mousePosition);
         RaycastHit raycastHit;

         if (Physics.Raycast(ray, out raycastHit, 100))
         {
            // check if we hit an interactable 
            Interactable interactable = raycastHit.collider.GetComponent<Interactable>();

            // set as focus
            if (interactable != null)
            {
               SetFocus(interactable);
            }
         }
      }
   }

   private void RemoveFocus()
   {
      if (focus != null)
         focus.OnDefocused();
      focus = null;
      motor.StopFollowingTarget();
   }

   void SetFocus(Interactable newFocus)
   {
      if(newFocus != focus)
      {
         if (focus!=null)
            focus.OnDefocused();
         focus = newFocus;
         motor.FollowTarget(newFocus);
      }

      newFocus.OnFocused(transform);
      
   }
}
