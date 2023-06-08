using ECSTemplates;
using Leopotam.Ecs;
using System.Linq;
using UnityEngine;

namespace Map
{ 
    public class InfoSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<SquadComponent/*, InPlayerRadiusVision*/, RefreshInfoEvent> _squadsContainedRefreshEvent = null;
        private EcsFilter<SquadComponent, InPlayerRadiusVision> _squadsInPlayerRadius = null;
        private EcsFilter<BuildingComponent> _buildings = null;
        private EcsFilter<SquadComponent, InPlayerRadiusVision, MouseEnterEvent> _squadMouseEnterEvent = null;
        private EcsFilter<SquadComponent, InPlayerRadiusVision, MouseExitEvent> _squadMouseExitEvent = null;
        private SceneData _sceneData = null;

        public void Init()
        {
            //_sceneData.SquadFullInfoUI.SetActive(false);
        }

        public void Run()
        {
            RefreshSquad();
            RotateSquad();
            MouseContactSquad();

            RotateBuilding();
        }

        private void MouseContactSquad()
        {
            foreach (var i in _squadMouseEnterEvent)
            {
                ref var squadComponent = ref _squadMouseEnterEvent.Get1(i);
                ref var mouseEventComponent = ref _squadMouseEnterEvent.Get3(i);

                var rectOffset = new Vector2(0, 150);
                
                //_sceneData.SquadFullInfoUI.RectTransform.position = mouseEventComponent.EventData.position + rectOffset;

                var commander = squadComponent.Commander;
                string text = null;
                _sceneData.SquadFullInfoUI.SquadName.text = squadComponent.Name;

                if(commander.Name != null)
                    text += commander.Name + " (" + commander.CurHealth / commander.MaxHealth * 100 + "%)";
                else
                {
                    text += "[Without Leader]";
                }

                foreach (var keyValue in squadComponent.UnitsDictionary.Dictionary)
                {
                    text += "\n" + keyValue.Key + " (" + keyValue.Value.Count() + ")";
                }
                foreach (var keyValue in squadComponent.PrisonersDictionary.Dictionary)
                {
                    text += "\n" + keyValue.Key + " (" + keyValue.Value.Count() + ")";
                }
                _sceneData.SquadFullInfoUI.FullInfo.text = text;
                _sceneData.SquadFullInfoUI.SetActive(true);
            }

            foreach (var i in _squadMouseExitEvent)
            {
                _sceneData.SquadFullInfoUI.SetActive(false);
            }
        }

        private void RefreshSquad()
        {
            foreach (var i in _squadsContainedRefreshEvent)
            {
                
                ref var entity = ref _squadsContainedRefreshEvent.GetEntity(i);
                ref var squadComponent = ref _squadsContainedRefreshEvent.Get1(i);
                int units = squadComponent.UnitsDictionary.Count() + 1; // 1 = leader of squad
                squadComponent.MonoBeh.CountUIInfo.text = units.ToString();
                int prisoners = squadComponent.PrisonersDictionary.Count();
                if (prisoners != 0)
                {
                    squadComponent.MonoBeh.CountUIInfo.text += " + " + prisoners;
                }
            }
        }

        private void RotateSquad()
        {
            foreach (var i in _squadsInPlayerRadius)
            {
                ref var squadComponent = ref _squadsInPlayerRadius.Get1(i);
                var squadRotation = squadComponent.MonoBeh.transform.rotation;

                squadComponent.MonoBeh.CountUIInfo.transform.rotation =
                    Quaternion.Euler(40, _sceneData.MainCamera.transform.rotation.eulerAngles.y - squadRotation.y, 0);
            }
        }

        private void RotateBuilding()
        {
            foreach (var i in _buildings)
            {
                ref var buildingComponent = ref _buildings.Get1(i);
                var buildingRotation = buildingComponent.MonoBeh.transform.rotation;

                buildingComponent.MonoBeh.UIInfo.transform.localRotation =
                    Quaternion.Euler(_sceneData.MainCamera.transform.rotation.eulerAngles.x, _sceneData.MainCamera.transform.rotation.eulerAngles.y - buildingRotation.y, 0);

                buildingComponent.MonoBeh.UIInfo.fontSize = (_sceneData.MainCamera.transform.rotation.eulerAngles.x - 40) * 0.5f + 5;
            }
        }
    }
}

