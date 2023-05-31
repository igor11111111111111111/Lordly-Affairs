using ECSTemplates;
using UnityEngine;

namespace Map
{
    public class SceneInit : MonoBehaviour
    {
        [SerializeField]
        private StaticData _staticData = null;
        [SerializeField]
        private SceneData _sceneData = null;
        [SerializeField]
        private UI _ui;
        [SerializeField]
        private UnitInfoUI _unitInfoUI;
        private EcsStartup _ecsStartup;

        void Awake()
        {
            _staticData.Init();
            _ecsStartup = new EcsStartup(_staticData, _sceneData);
            _ecsStartup.Start();
            _ui.Init(_ecsStartup.EcsWorld);
            _unitInfoUI.Init(_staticData.UnitData.Mesh);
        }

        private void Update()
        {
            _ecsStartup.Update();
        }

        private void OnDestroy()
        {
            _ecsStartup.OnDestroy();
        }
    }
}

