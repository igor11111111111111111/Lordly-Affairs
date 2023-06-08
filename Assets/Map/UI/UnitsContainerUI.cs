using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace Map
{
    public class UnitsContainerUI : MonoBehaviour
    {
        private UnitInfoUI _unitInfoUI;
        [SerializeField] private Transform _parent;
        [SerializeField] private TextMeshProUGUI _unitsCount;
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

            ShowCommander();
            // show companions

            foreach (var keyValue in _playerSquad.UnitsDictionary.Dictionary)
            {
                var btnUI = Instantiate(_buttonUI, _parent);
                btnUI.gameObject.name = keyValue.Key;
                btnUI.Text.text = keyValue.Key + " (" + keyValue.Value.Count() + ")";
                btnUI.Button.onClick.AddListener(() => _unitInfoUI.ShowUnit(keyValue, ref _playerSquad.UnitsDictionary));
            };

            var allUnitsCount = _playerSquad.UnitsDictionary.Count() + 1; // 1 - commander
            _unitsCount.text = "Warriors: " + allUnitsCount + " / " + _playerSquad.MaxSquadSize;
        }

        private void ShowCommander()
        {
            var commander = _playerSquad.Commander;
            var btnUI = Instantiate(_buttonUI, _parent);
            btnUI.gameObject.name = commander.Name;
            btnUI.Text.text = commander.Name + " (" + commander.CurHealth / commander.MaxHealth * 100 + "%)";
            btnUI.Button.onClick.AddListener(() => _unitInfoUI.ShowCommander(commander));
        }
    }
}