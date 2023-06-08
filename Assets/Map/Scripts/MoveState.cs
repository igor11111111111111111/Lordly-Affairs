using Leopotam.Ecs;
using Map;
using UnityEngine;

namespace StateMachine
{
    public class MoveState : State
    {
        public override void Enter()
        {
            base.Enter();
            //Debug.Log("move Enter");
            ref var squadComponent = ref _entity.Get<SquadComponent>();

            squadComponent.NavMeshAgent.velocity = Vector3.zero;
            squadComponent.NavMeshAgent.destination = squadComponent.Target.Position;
            squadComponent.NavMeshAgent.speed = squadComponent.Speed;
            squadComponent.NavMeshAgent.isStopped = false;
            squadComponent.Animator.SetBool("IsMove", true);
            squadComponent.Transform.LookAt(squadComponent.Target.Position);
            squadComponent.Transform.eulerAngles = 
                new Vector3(0, squadComponent.Transform.eulerAngles.y, 0);
        }

        public override void Update()
        {
            //Debug.Log("move");
            ref var state = ref _entity.Get<StateComponent>();
            ref var squadComponent = ref _entity.Get<SquadComponent>();

            if (squadComponent.Target is SquadComponent)
            {
                squadComponent.NavMeshAgent.destination = squadComponent.Target.Position;
                squadComponent.Transform.LookAt(squadComponent.Target.Position);
            }

            if (ReachedTarget())
            {
                if(squadComponent.Target is SquadComponent)
                {
                    state.ChangeState<PlayerRelationshipState>();
                }
                else if (state.StateMachine.PrevState is IdleState ||
                            state.StateMachine.PrevState is MoveState)
                {
                    state.ChangeState<IdleState>();
                }

                if (state.StateMachine.PrevState is PatrolState)
                {
                    state.ChangeState<PatrolState>();
                }
                else if (state.StateMachine.PrevState is RecrutingState)
                {
                    state.ChangeState<RecrutingState>();
                }
            }
        }

        public override void Exit()
        {
            base.Exit();

            ref var squadComponent = ref _entity.Get<SquadComponent>();

            squadComponent.NavMeshAgent.velocity = Vector3.zero;
            squadComponent.NavMeshAgent.isStopped = true;
            squadComponent.Animator.SetBool("IsMove", false);
        }

        private bool ReachedTarget()
        {
            ref var squadComponent = ref _entity.Get<SquadComponent>();

            if (squadComponent.Target  != null &&
                squadComponent.Transform.position.x == squadComponent.Target.Position.x &&
                squadComponent.Transform.position.z == squadComponent.Target.Position.z)
            {
                return true;
            }
            else if (squadComponent.Target != null && squadComponent.Target is SquadComponent &&
                Vector3.Magnitude(squadComponent.Transform.position -squadComponent.Target.Position) <= 0.5f)
            {
                return true;
            }
            return false;
        }
    }
}

