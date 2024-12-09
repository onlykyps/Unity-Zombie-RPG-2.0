using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   public float lookRadius = 10f;
   Transform target;
   NavMeshAgent agent;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      agent = GetComponent<NavMeshAgent>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   private void OnDrawGizmosSelected()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, lookRadius);
   }
}
