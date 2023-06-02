using Map;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace PlayerRedactor
{
    public class FaceRedactorPanel : MonoBehaviour
    {
        [SerializeField] private FacePanel _facePanel;
        [SerializeField] private Button _next;
        [SerializeField] private Button _previous;

        public ButtonClickedEvent Init(ButtonClickedEvent infPanelNext, UnitModel unitModel)
        {
            infPanelNext.AddListener(() => SetActive(true));
            _previous.onClick.AddListener(() => SetActive(false));
            _next.onClick.AddListener(() => SceneManager.LoadScene("Map"));
            SetActive(false);

            Instantiate(_facePanel, transform).Init<Hair>(unitModel);
            Instantiate(_facePanel, transform).Init<Head>(unitModel);
            Instantiate(_facePanel, transform).Init<FacialHair>(unitModel);
            Instantiate(_facePanel, transform).Init<Eyebrow>(unitModel);

            return _previous.onClick;
        }

        private void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}

