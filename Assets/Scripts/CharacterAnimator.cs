using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
   NavMeshAgent agent;
   Animator animator;

   const float locomotionAnimationSmoothTime = .1f;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      agent = GetComponent<NavMeshAgent>();
      animator = GetComponentInChildren<Animator>();

   }

   // Update is called once per frame
   void Update()
   {
      float speedPercent = agent.velocity.magnitude / agent.speed;
      animator.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);
   }
}
