using Map;
using UnityEngine;

namespace PlayerRedactor
{
    public class UI : MonoBehaviour
    { 
        [SerializeField] private InformationPanel _informationPanel;
        [SerializeField] private FaceRedactorPanel _faceRedactorPanel;
        [SerializeField] private UnitRotator _unitRotator;

        public void Init(UnitModel unitModel)
        {
            var infPanelNext = _informationPanel.Init();
            var faceRedactorPrevious = _faceRedactorPanel.Init(infPanelNext, unitModel);
            _informationPanel.Init(faceRedactorPrevious);
            _unitRotator.Init(unitModel);
        }
    }
}

