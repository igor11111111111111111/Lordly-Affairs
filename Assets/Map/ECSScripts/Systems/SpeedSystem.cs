using ECSTemplates;
using Leopotam.Ecs;

namespace Map
{
    public class SpeedSystem : IEcsInitSystem
    {
        private EcsFilter<SquadComponent> filter = null;

        public void Init()
        {
            foreach (var i in filter)
            {
                ref var speed = ref filter.Get1(i).Speed;
                speed = 3; // morale etc
            }
        }
    }
}

