using Leopotam.Ecs;
using Map;
using UnityEngine;

namespace StateMachine
{

    public class PatrolState : State
    {
        private ITarget _target = null;

        public override void Enter()
        {
            base.Enter();
            //Debug.Log("patrol");
            int radiusMove = 10;

            ref var squadComponent = ref _entity.Get<SquadComponent>();
            ref var stateComponent = ref _entity.Get<StateComponent>();
            var handler = new FindManager(squadComponent, _ecsWorld);

            _target = handler.GetBuilding(FindInfo.MyDomain);
            if (_target == null)
                _target = handler.GetBuilding(FindInfo.MyFactionDomain);

            var random = new System.Random();
            var newPosition = _target.Position + new Vector3(random.Next(-radiusMove, radiusMove), 0, random.Next(-radiusMove, radiusMove));
            squadComponent.Target = new GroundTarget(newPosition);

            _entity.Get<StateComponent>().ChangeState<MoveState>();
        }
    }
}

