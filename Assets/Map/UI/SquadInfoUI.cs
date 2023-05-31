﻿using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace Map
{
    public class SquadInfoUI : MonoBehaviour
    {
        [SerializeField] private Text _gold;
        [SerializeField] private Text _salary;
        [SerializeField] private Text _morale;
        private SquadComponent _playerSquad;

        public void Init(ref SquadComponent playerSquad, ButtonClickedEvent onClickCompanyBtn, ButtonClickedEvent onClickDisbandBtn)
        {
            _playerSquad = playerSquad;
            onClickCompanyBtn.AddListener(Show);
            onClickDisbandBtn.AddListener(Show);
        }

        private void Show()
        {
            _salary.text = "Day salary: " + _playerSquad.UnitsDictionary.AllSalary().ToString();
            _gold.text = "Gold: " + _playerSquad.Gold;
            _morale.text = "Squad morale: " + "Good"; /*_playerSquad.UnitsDictionary.AllMorale().ToString();*/
        }
    }
}