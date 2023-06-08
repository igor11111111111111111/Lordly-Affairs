using Leopotam.Ecs;
using Map;
using UnityEngine;

namespace StateMachine
{
    public class RecrutingState : State
    {
        public override void Enter()
        {
            //Debug.Log("recruting ENTER");
            base.Enter();
            _delay = 300;

            if (_entity.Get<StateComponent>().StateMachine.PrevState is EntryState)
            {
                ref var squadComponent = ref _entity.Get<SquadComponent>();
                var handler = new FindManager(squadComponent, _ecsWorld);
                squadComponent.Target = handler.GetBuilding(FindInfo.MyFactionDomain);
                
                _entity.Get<StateComponent>().ChangeState<MoveState>();
            }
        }

        public override void CustomUpdate()
        {
            //Debug.Log("recruting UPDATE");
            ref var squadComponent = ref _entity.Get<SquadComponent>();

            var rand = new System.Random().Next(2);
            if (rand == 0)
                HireUnit<Militia>();
            else if(rand == 1)
                HireUnit<Peasant>();

            if (squadComponent.UnitsDictionary.Count() >= squadComponent.PatrolUnitTreshold)
            {
                _entity.Get<StateComponent>().ChangeState<PatrolState>();
            }
        }

        private void HireUnit<Unit>() where Unit : IUnit, new()
        {
            var unit = new Unit();
            ref var squadComponent = ref _entity.Get<SquadComponent>();
            squadComponent.UnitsDictionary.Add(unit);
            squadComponent.Gold -= unit.Price;

            _entity.Get<RefreshInfoEvent>();
        }
    }
}

