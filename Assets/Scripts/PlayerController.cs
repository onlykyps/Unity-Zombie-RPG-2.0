using UnityEngine;

public class PlayerController : MonoBehaviour
{
   Camera camera;
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      camera = Camera.main;
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("0"))
      {
         Ray ray = camera.ScreenPointToRay(Input.mousePosition);
         RaycastHit raycastHit;

         if(Physics.Raycast(ray, out raycastHit))
         {
            // move our player to what we hit

            // stop focusing any objects
         }
      }
   }
}
