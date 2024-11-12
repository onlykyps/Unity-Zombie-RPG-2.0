using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
   NavMeshAgent meshAgent;
   Transform target;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      meshAgent = GetComponent<NavMeshAgent>();
   }

   // Update is called once per frame
   void Update()
   {
      if (target != null)
      {
         meshAgent.SetDestination(target.position);
         FaceTarget();
      }
   }

   void FaceTarget()
   {
      Vector3 direction = (target.position - transform.position).normalized;
      Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
      transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); 
   }

   public void MoveToPoint(Vector3 point)
   {
      meshAgent.SetDestination(point);
   }

   public void FollowTarget(Interactable newTarget)
   {
      meshAgent.stoppingDistance = newTarget.radius * .8f;
      meshAgent.updateRotation = false;
      target = newTarget.interactionTransform;
   }

   public void StopFollowingTarget()
   {
      meshAgent.stoppingDistance = 0f;
      meshAgent.updateRotation = true;
      target = null;
   }
}
