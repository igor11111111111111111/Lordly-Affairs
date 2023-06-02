using Map;
using UnityEngine;

namespace PlayerRedactor
{
    public class UI : MonoBehaviour
    { 
        [SerializeField] private InformationPanel _informationPanel;
        [SerializeField] private FaceRedactorPanel _faceRedactorPanel;
        [SerializeField] private UnitRotator _unitRotator;
        [SerializeField] private GameObject _dragTextAnimation;

        public void Init(UnitModel unitModel)
        {
            _dragTextAnimation.gameObject.SetActive(false);

            var infPanelNext = _informationPanel.Init(_dragTextAnimation);
            var faceRedactorPrevious = _faceRedactorPanel.Init(infPanelNext, unitModel);
            _informationPanel.Init(faceRedactorPrevious);
            _unitRotator.Init(unitModel, _dragTextAnimation);
        }
    }
}

