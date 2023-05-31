using Leopotam.Ecs;
using System.Linq;
using UnityEngine;

namespace Map
{
    public class PlayerVisionSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTag, SquadComponent> _filter = null;
        private EcsWorld _ecsWorld;
         
        public void Run()
        {
            foreach (var i in _filter)
            {
                //var squadComponent = _filter.Get2(i);
                //var colliders = Physics.OverlapSphere(squadComponent.Transform.position, squadComponent.RadiusVision);
                //var squads = colliders
                //    .Select(c => c.GetComponent<Squad>())
                //    .Where(s => !s.Equals(squadComponent));
                //foreach (var item in squads)
                //{
                //    Debug.Log(item.name);
                //}

                //var squadPos = squadComponent.Transform.position;

                //EcsEntity[] allEntity = null;
                //_ecsWorld.GetAllEntities(ref allEntity);

                //var visibleUnits = allEntity
                //    .Where(e => e.Has<SquadComponent>())
                //    .Select(e => e.Get<SquadComponent>())
                //    .Where(
                //    e => !e.Equals(squadComponent) && Vector3.Magnitude(e.Transform.position - squadComponent.Transform.position) <= squadComponent.RadiusVision)
                //    .ToList();

                //foreach (var unit in visibleUnits)
                //{
                //    unit.MonoBeh.UIInfo.gameObject.SetActive(false);
                //    unit.MonoBeh.LeaderModel.gameObject.SetActive(false);
                //    //unit.MonoBeh.gameObject.SetActive(false);
                //}
            }
        }
    }
}