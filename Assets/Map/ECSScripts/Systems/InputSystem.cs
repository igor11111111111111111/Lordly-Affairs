using ECSTemplates;
using Leopotam.Ecs;
using UnityEngine;

namespace Map
{
    public class InputSystem : IEcsInitSystem
    {
        private SceneData _sceneData = null;
        private EcsFilter<PlayerTag, SquadComponent> filter = null;

        public void Init()
        {
            _sceneData.PositionOnGesture.OnMove += Move;
        }

        private void Move(Vector3 targetPos)
        {
            foreach (var i in filter)
            {
                var target = new GroundTarget(targetPos);
                filter.Get2(i).Target = target;
                filter.GetEntity(i).Get<FoundTargetEvent>().Target = target;
            }
        }
    }
} 

