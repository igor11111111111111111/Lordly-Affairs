using Leopotam.Ecs;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Map
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private ButtonUI _buttonUIPrefab;
        [SerializeField] private CompanyUI _companyUI;
        [SerializeField] private DialogUI _dialogUI;
        [SerializeField] private ButtonUI _accept;
        [SerializeField] private ButtonUI _talk;

        public void Init(EcsWorld ecsWorld)
        {
            EcsEntity[] allEntity = null;
            ecsWorld.GetAllEntities(ref allEntity);
            var playerEntity =  allEntity.First(e => e.Has<PlayerTag>());
            ref var playerSquad = ref playerEntity.Get<SquadComponent>();

            var companyButtonUI = Instantiate(_buttonUIPrefab, _parent);
            companyButtonUI.name = "CompanyBtn";
            companyButtonUI.Text.text = "Company";

            _companyUI.Init(ref playerSquad, _buttonUIPrefab, companyButtonUI.Button.onClick, _accept.Button.onClick);
            _dialogUI.Init(_talk.Button.onClick);

            _accept.Button.onClick.AddListener(() => playerEntity.Get<RefreshInfoEvent>());
        }
    }
}