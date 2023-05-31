using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace Map
{
    public class PrisonersContainerUI : MonoBehaviour
    { 
        private UnitInfoUI _unitInfoUI;
        [SerializeField] private Transform _parent;
        [SerializeField] private Text _unitsCount;
        private SquadComponent _playerSquad;
        private ButtonUI _buttonUI;

        public void Init(UnitInfoUI unitInfoUI, ref SquadComponent playerSquad, ButtonUI buttonUI, ButtonClickedEvent onClickCompanyBtn, ButtonClickedEvent onClickDisbandBtn)
        {
            _unitInfoUI = unitInfoUI;
            _playerSquad = playerSquad;
            _buttonUI = buttonUI;
            _buttonUI.GetComponent<RectTransform>().sizeDelta = new Vector2(204, 23);
            onClickCompanyBtn.AddListener(Show);
            onClickDisbandBtn.AddListener(Show);
            // onclick exit btn removealllisteners from btnUI.Button
        }

        private void Show()
        {
            foreach (Transform child in _parent)
            {
                Destroy(child.gameObject);
            }
            foreach (var keyValue in _playerSquad.PrisonersDictionary.Dictionary)
            {
                var btnUI = Instantiate(_buttonUI, _parent);
                btnUI.gameObject.name = keyValue.Key;
                btnUI.Text.text = keyValue.Key + " (" + keyValue.Value.Count() + ")";
                btnUI.Button.onClick.AddListener(() => _unitInfoUI.ShowPrisoner(keyValue, ref _playerSquad.PrisonersDictionary));
            };
            _unitsCount.text = "Prisoners: " + _playerSquad.PrisonersDictionary.Count() + " / " + _playerSquad.MaxPrisonersSize;
        }
    }
}