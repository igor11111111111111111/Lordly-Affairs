using TMPro;
using UnityEngine;

namespace Map
{
    public class SquadFullInfoUI : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI SquadName;
        [SerializeField] public TextMeshProUGUI FullInfo;
        [SerializeField] public RectTransform RectTransform;

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}

