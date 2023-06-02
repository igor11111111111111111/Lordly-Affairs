using Map;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerRedactor
{
    public class FacePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Button _next;
        [SerializeField] private Button _previous;
        private UnitModel _unitModel;
        private int _id;

        public void Init<T>(UnitModel unitModel) where T : ICloth
        {
            _unitModel = unitModel;
            _name.text = typeof(T).Name;
            _id = 1;
            _next.onClick.AddListener(Next<T>);
            _previous.onClick.AddListener(Previous<T>);
        }

        private void Next<T>()
        {
            _id++;
            _unitModel.ClothChanger.Set<T>(ref _id);
        }

        private void Previous<T>()
        {
            _id--;
            _unitModel.ClothChanger.Set<T>(ref _id);
        }
    }
}