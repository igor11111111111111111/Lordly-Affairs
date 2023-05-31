using ECSTemplates;
using Leopotam.Ecs;
using UnityEngine;
using System;

namespace Map
{

    public class MoveSystem : IEcsRunSystem
    { 
        private EcsFilter<SquadComponent> _filter = null;
        private EcsWorld _ecsWorld;
         
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var squadComponent = ref _filter.Get1(i);
                ref var navMeshAgent = ref squadComponent.NavMeshAgent;
                ref var animator = ref squadComponent.Animator;

                if (entity.Has<FoundTargetEvent>())
                {
                    //Debug.Log("FoundTargetEvent");
                    entity.Get<CheckReachedTargetState>();

                    ref var transform = ref squadComponent.Transform;
                    ref var target = ref squadComponent.Target;
                    ref var speed = ref squadComponent.Speed;

                    navMeshAgent.velocity = Vector3.zero;
                    navMeshAgent.destination = target.Position;
                    navMeshAgent.speed = speed;
                    navMeshAgent.isStopped = false;
                    animator.SetBool("IsMove", true);
                    transform.LookAt(target.Position);
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                }
                else if (entity.Has<ReachedTargetEvent>())
                {
                    //Debug.Log("ReachedTargetEvent");
                    navMeshAgent.velocity = Vector3.zero;
                    navMeshAgent.isStopped = true;
                    animator.SetBool("IsMove", false);
                    squadComponent.Target = null;
                    entity.Del<MoveState>();
                }
            }
        }
    }
}

