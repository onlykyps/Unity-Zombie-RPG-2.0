using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Transform target;
   public Vector3 offset;

   public float pitch = 2f;

   private float currentZoom = 10f;

   public float zoomSpeed = 4f;
   public float minZoom = 5f;
   public float maxZoom = 15f;

   public float yawSpeed = 100f;
   private float currentYaw = 0f;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      currentZoom -= Input.GetAxis("MouseScrollWheel") * zoomSpeed;

      currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

      currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
   }

   private void LateUpdate()
   {
      transform.position = target.position - offset * currentZoom;
      transform.LookAt(target.position + Vector3.up * pitch);
      transform.RotateAround(target.position, Vector3.up, currentYaw);
   }

}
