using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace Map
{
    public class CompanyUI : MonoBehaviour
    {
        [SerializeField] private UnitsContainerUI _unitsContainer;
        [SerializeField] private PrisonersContainerUI _prisonersContainer;
        [SerializeField] private UnitInfoUI _unitInfoUI;
        [SerializeField] private SquadInfoUI _squadInfoUI;
        [SerializeField] private ButtonUI _talk;
        [SerializeField] private ButtonUI _disband;
         
        public void Init(ref SquadComponent playerSquad, ButtonUI buttonUI, 
            ButtonClickedEvent onClickCompanyBtn, ButtonClickedEvent onClickAcceptBtn)
        {
            var onClickDisbandBtn = _disband.Button.onClick;
            _unitInfoUI
                .Init(onClickCompanyBtn, onClickDisbandBtn, _talk.gameObject, _disband.gameObject);
            _unitsContainer
                .Init(_unitInfoUI, ref playerSquad, buttonUI, onClickCompanyBtn, onClickDisbandBtn);
            _prisonersContainer
                .Init(_unitInfoUI, ref playerSquad, buttonUI, onClickCompanyBtn, onClickDisbandBtn);
            _squadInfoUI
                .Init(ref playerSquad, onClickCompanyBtn, onClickDisbandBtn);

            onClickCompanyBtn.AddListener(() => Show(true));
            onClickAcceptBtn.AddListener(() => Show(false));

            Show(false);
        } 
         
        private void Show(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}