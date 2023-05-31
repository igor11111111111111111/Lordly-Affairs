using Map;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class SceneData : MonoBehaviour
    {
        public Camera MainCamera; 
        public PositionOnGesture PositionOnGesture;
        public PlayerVision PlayerVisionPrefab;
        public Transform BuildingsContainer;
        public Transform UnitsContainer;
        public SquadFullInfoUI SquadFullInfoUI;
    }
}

