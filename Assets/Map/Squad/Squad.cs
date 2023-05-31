using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Map
{
    public class Squad : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] public UnitModel LeaderModel;
        [SerializeField] public TextMeshPro CountUIInfo;
        [SerializeField] public BoxCollider TriggerCollider;
        [SerializeField] public NavMeshAgent NavMeshAgent;
        public EcsEntity Entity;

        public void OnPointerEnter(PointerEventData eventData)
        {
            Entity.Get<MouseEnterEvent>().EventData = eventData;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Entity.Get<MouseExitEvent>().EventData = eventData;
        }
         
        public void SetActive(bool active)
        {
            CountUIInfo.gameObject.SetActive(active);
            LeaderModel.SetActive(active);
        }
    }
}
