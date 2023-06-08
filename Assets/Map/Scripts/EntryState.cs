using Leopotam.Ecs;
using Map;
using UnityEngine;

namespace StateMachine
{
    public class EntryState : State
    { 
        public override void CustomUpdate()
        {
            //Debug.Log("idle");
            ref var squadComponent = ref _entity.Get<SquadComponent>();

            if (squadComponent.Gold >= squadComponent.GoldTreshold &&
                   squadComponent.UnitsDictionary.Count() < squadComponent.PatrolUnitTreshold)
            {
                _entity.Get<StateComponent>().ChangeState<RecrutingState>();
            }
            else
            {
                if (squadComponent.Honor >= 0)
                {
                    //_stateMachine.ChangeState(_logic.Patrol);
                }
                else
                {
                    //_stateMachine.ChangeState(_logic.FindTarget);
                }
            }
        }
    }
}

