using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace Map
{
    public class DialogUI : MonoBehaviour
    {
        [SerializeField] private ButtonUI _neverMind;

        public void Init(ButtonClickedEvent onClickTalkBtn)
        {
            onClickTalkBtn.AddListener(() => Show(true));
            _neverMind.Button.onClick.AddListener(() => Show(false));

            Show(false);
        }

        private void Show(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}