using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
   public LayerMask movementMask;
   Camera camera;
   PlayerMotor motor;

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

         if(Physics.Raycast(ray, out raycastHit, 100, movementMask))
         {
            // move our player to what we hit
            motor.MoveToPoint(raycastHit.point);

            // stop focusing any objects
         }
      }

      if (Input.GetMouseButtonDown(1))
      {
         Ray ray = camera.ScreenPointToRay(Input.mousePosition);
         RaycastHit raycastHit;

         if (Physics.Raycast(ray, out raycastHit, 100))
         {
           // check if we hit an interactable 
           // set as focus
         }
      }
   }
}
