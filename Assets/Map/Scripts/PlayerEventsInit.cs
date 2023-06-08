using Leopotam.Ecs;
using Map;
using UnityEngine;

namespace StateMachine
{
    public class PlayerEventsInit : State
    {
        public PlayerEventsInit(SceneData sceneData)
        {
            sceneData.PositionOnGesture.OnMove += Move;
        }

        private void Move(Vector3 targetPos)
        {
            var target = new GroundTarget(targetPos);
            _entity.Get<SquadComponent>().Target = target;
            _entity.Get<StateComponent>().ChangeState<MoveState>();
        }
    }
}

