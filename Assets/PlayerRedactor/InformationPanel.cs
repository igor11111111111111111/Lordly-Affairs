using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace PlayerRedactor
{
    public class InformationPanel : MonoBehaviour
    {
        [SerializeField] TMP_InputField _playerName;
        [SerializeField] TMP_InputField _squadName;
        [SerializeField] Button _next;

        public ButtonClickedEvent Init()
        {
            SetActive(true);
            _next.onClick.AddListener(
            () =>
            {
                SetActive(false);
            });

            return _next.onClick;
        }

        public void Init(ButtonClickedEvent faceRedactorPrevious)
        {
            faceRedactorPrevious.AddListener(() => SetActive(true));
        }

        private void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}

