using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace Map
{
    public class UnitInfoUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private UnitModel _unitModel;
        [SerializeField] private Text _name;
        [SerializeField] private Text _salary;
        [SerializeField] private Text _morale;
        [SerializeField] private GameObject _body;
        private List<Mesh> _mesh;
        private UnitsDictionary _dictionary;
        private KeyValuePair<string, List<IUnit>> _keyValuePair;
        private PointerEventData _eventData = null;
        private GameObject _talk;
        private GameObject _disband;

        public void Init(ButtonClickedEvent onClickCompanyBtn, ButtonClickedEvent onClickDisbandBtn
            , GameObject talk, GameObject disband)
        {
            _talk = talk;
            _disband = disband;

            onClickCompanyBtn.AddListener(() => { _body.SetActive(false);});
            onClickDisbandBtn.AddListener(Disband);
        }

        public void Init(List<Mesh> mesh)
        {
            _mesh = mesh;
        }

        public void ShowUnit(KeyValuePair<string, List<IUnit>> keyValuePair, 
            ref UnitsDictionary dictionary)
        {
            _body.SetActive(true);
            _talk.SetActive(true);
            _disband.SetActive(true);
            var findedMesh = _mesh.First(m => m.name == keyValuePair.Key);
            _unitModel.SkinnedMeshRenderer.sharedMesh = findedMesh;
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
            var findedMesh = _mesh.First(m => m.name == keyValuePair.Key);
            _unitModel.SkinnedMeshRenderer.sharedMesh = findedMesh;
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
            var findedMesh = _mesh.First(m => m.name == "Commander");
            _unitModel.SkinnedMeshRenderer.sharedMesh = findedMesh;
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