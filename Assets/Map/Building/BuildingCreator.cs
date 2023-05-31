using ECSTemplates;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Map
{
    //public class BuildingCreator
    //{
    //    private EcsWorld _ecsWorld = null;
    //    private StaticData _staticData = null;
    //    private SceneData _sceneData = null;

    //    public BuildingCreator(EcsWorld ecsWorld, StaticData staticData, SceneData sceneData)
    //    {
    //        _ecsWorld = ecsWorld;
    //        _staticData = staticData;
    //        _sceneData = sceneData;
    //    } 

    //    public EcsEntity Create(BuildingInfo buildinginfo)
    //    {
    //        EcsEntity building = _ecsWorld.NewEntity();
    //        GameObject go = Object.Instantiate(_staticData.BuildingData.Prefab, buildinginfo.Position, Quaternion.identity);
    //        go.name = buildinginfo.Name;
    //        go.GetComponent<Building>().SkinnedMeshRenderer.sharedMesh = _staticData.BuildingData.GetMesh(buildinginfo.Type);
             
    //        ref var buildingComponent = ref building.Get<BuildingComponent>();
    //        buildingComponent.Transform = go.transform;
    //        buildingComponent.Name = buildinginfo.Name;
    //        buildingComponent.Type = buildinginfo.Type;

    //        return building;
    //    }
    //}
}

