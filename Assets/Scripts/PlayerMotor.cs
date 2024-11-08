using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
   NavMeshAgent meshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      meshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void MoveToPoint(Vector3 point)
   {
      meshAgent.SetDestination(point);
   }
}
