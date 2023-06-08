using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace Map
{
    public class UnitInfoUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    { 
        [SerializeField] private UnitModel _unitModel;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _salary;
        [SerializeField] private TextMeshProUGUI _morale;
        [SerializeField] private GameObject _body;
        private UnitsDictionary _dictionary;
        private KeyValuePair<string, List<IUnit>> _keyValuePair;
        private PointerEventData _eventData = null;
        private GameObject _talk;
        private GameObject _disband;
        private AllClothMesh _allClothMesh;

        public void Init(ButtonClickedEvent onClickCompanyBtn, ButtonClickedEvent onClickDisbandBtn
            , GameObject talk, GameObject disband)
        {
            _talk = talk;
            _disband = disband;

            onClickCompanyBtn.AddListener(() => { _body.SetActive(false);});
            onClickDisbandBtn.AddListener(Disband);
        }

        public void Init(AllClothMesh allClothMesh)
        {
            _allClothMesh = allClothMesh;
        }

        public void ShowUnit(KeyValuePair<string, List<IUnit>> keyValuePair, 
            ref UnitsDictionary dictionary)
        {
            _body.SetActive(true);
            _talk.SetActive(true);
            _disband.SetActive(true);
            _unitModel.ClothChanger.Set(keyValuePair.Value[0].AllCloth, _allClothMesh);
            _salary.text = "Day salary: " + keyValuePair.Value[0].Salary;
            _morale.text = "Morale: Good"; /*"Morale: " + keyValuePair.Value[0].Morale;*/
            _name.text = keyValuePair.Value[0].GetType().Name.ToString();

            _keyValuePair = keyValuePair;
            _dictionary = dictionary; 
        }

        public void ShowPrisoner(KeyValuePair<string, List<IUnit>> keyValuePair,
            ref UnitsDictionary dictionary)
        {
            _body.SetActive(true);
            _talk.SetActive(true);
            _disband.SetActive(true);
            _unitModel.ClothChanger.Set(keyValuePair.Value[0].AllCloth, _allClothMesh);
            _salary.text = "";
            _morale.text = "";
            _name.text = keyValuePair.Value[0].GetType().Name.ToString();

            _keyValuePair = keyValuePair;
            _dictionary = dictionary;
        }

        public void ShowCommander(CommanderComponent commander)
        {
            _body.SetActive(true);
            _talk.SetActive(false);
            _disband.SetActive(false);
            _unitModel.ClothChanger.Set(commander.AllCloth, _allClothMesh);
            _salary.text = "";
            _morale.text = "";
            _name.text = commander.Name;
        }

        private void Disband()
        {
            _dictionary.Remove(_keyValuePair.Key);
            if(!_dictionary.Contain(_keyValuePair.Key))
                _body.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _eventData = eventData;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _eventData = null;
        }

        private void Update()
        {
            if (_eventData == null) return;
            _unitModel.transform.Rotate(0, -_eventData.delta.x, 0);
        }
    }
}